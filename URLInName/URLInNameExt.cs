// <copyright file="URLInNameExt.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace URLInName
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePass.Plugins;
    using KeePass.Resources;
    using KeePassLib;

    /// <summary>
    /// Class for extension: Simplifies url, and renames entry to domain from URL.
    /// </summary>
    public sealed class URLInNameExt : Plugin
    {
        private IPluginHost host;

        private ToolStripSeparator tsSeparator = null;
        private ToolStripMenuItem tsmiAddGroups = null;

        /// <inheritdoc/>
        public override bool Initialize(IPluginHost host_)
        {
            this.host = host_;

            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection tsMenu = this.host.MainWindow.ToolsMenu.DropDownItems;

            // Add a separator at the bottom
            this.tsSeparator = new ToolStripSeparator();
            tsMenu.Add(this.tsSeparator);

            // Add menu item 'Suggest URL In Title'
            this.tsmiAddGroups = new ToolStripMenuItem
            {
                Text = "Suggest &URL In Title",
            };
            this.tsmiAddGroups.Click += (sender, args) => this.OnRunClicked();
            tsMenu.Add(this.tsmiAddGroups);

            return true;
        }

        /// <inheritdoc/>
        public override void Terminate()
        {
            // Remove all of our menu items
            ToolStripItemCollection tsMenu = this.host.MainWindow.ToolsMenu.DropDownItems;
            tsMenu.Remove(this.tsSeparator);
            tsMenu.Remove(this.tsmiAddGroups);
        }

        /// <summary>
        /// Method called when the user runs the extension.
        /// </summary>
        public void OnRunClicked()
        {
            List<SuggestedModification> suggestedModifications = new List<SuggestedModification>();

            foreach (PwEntry i in this.host.Database.RootGroup.GetEntries(true))
            {
                string entryName = i.Strings.Get(KPRes.Title).ReadString();
                string entryURL = i.Strings.Get(KPRes.Url).ReadString();

                try
                {
                    suggestedModifications.Add(SuggestModification(entryURL, entryName, i.Uuid));
                }
                catch (Exception)
                {
                    ////logger.Log(string.Format("For URL:{0}, exception:{1}", entryURL, ex.ToString()));
                }
            }

            CheckboxTableForm changes_form = new CheckboxTableForm();
            changes_form.AddData(suggestedModifications);
            changes_form.ShowDialog();

            suggestedModifications = changes_form.SuggestedModifications;

            foreach (SuggestedModification item in suggestedModifications)
            {
                PwEntry entry = this.host.Database.RootGroup.FindEntry(item.Uuid, true);

                entry.Strings.Set(KPRes.Title, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Title).IsProtected, item.NewTitle));
                entry.Strings.Set(KPRes.Url, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Url).IsProtected, item.SuggestedUrl));
                entry.LastModificationTime = DateTime.Now;
            }

            this.host.MainWindow.UpdateUI(false, null, true, this.host.Database.RootGroup, true, null, true);
        }

        /// <summary>
        /// Creates a suggested modification to a potential change.
        /// </summary>
        /// <param name="url">The input url which we will use to generate the URL and name.</param>
        /// <param name="name">The current entry name.</param>
        /// <param name="uuid">The uuid of the <see cref="PwEntry"/>.</param>
        /// <returns>A struct with the old name and url, and the new suggestions.</returns>
        public static SuggestedModification SuggestModification(string url, string name, PwUuid uuid)
        {
            Uri asUri = new UriBuilder(url).Uri;
            string suggestedName = asUri.Host
                .RemoveStart("www.")
                .RemoveStart("account.")
                .RemoveStart("accounts.")
                .RemoveStart("signin.")
                .RemoveStart("secure.")
                .RemoveStart("auth.")
                .RemoveStart("ssl.")
                .RemoveStart("my.")
                .RemoveStart("m.")
                .RemoveStart("login.")
                .RemoveStart("support.")
                .RemoveStart("forums.")
                .RemoveStart("sso.")
                .RemoveStart("signup.");
            string suggestUrl = asUri.GetLeftPart(UriPartial.Authority);

            if (!string.Equals(name, suggestedName) || !string.Equals(url, suggestUrl))
            {
                return new SuggestedModification()
                {
                    NewTitle = suggestedName, OldTitle = name, OldUrl = url, SuggestedUrl = suggestUrl, Uuid = uuid,
                };
            }
            else
            {
                throw new Exception(string.Format("Skipping entry with name: {0} and url: {1}", name, url));
            }
        }
    }

    /// <summary>
    /// A struct holding the old values, and new suggested values, for displaying in the UI.
    /// </summary>
    public struct SuggestedModification
    {
        /// <summary>
        /// The previous entry Title.
        /// </summary>
        public string OldTitle;

        /// <summary>
        /// The new suggested title.
        /// </summary>
        public string NewTitle;

        /// <summary>
        /// The previous entry URL.
        /// </summary>
        public string OldUrl;

        /// <summary>
        /// The new suggested URL.
        /// </summary>
        public string SuggestedUrl;

        /// <summary>
        /// The UUID of the entry to reassociate later.
        /// </summary>
        public PwUuid Uuid;
    }
}