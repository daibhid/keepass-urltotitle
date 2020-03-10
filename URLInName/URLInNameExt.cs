namespace URLInName
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePass.Plugins;
    using KeePass.Resources;
    using KeePassLib;

    public sealed class URLInNameExt : Plugin
    {
        private IPluginHost host;

        private ToolStripSeparator m_tsSeparator = null;
        private ToolStripMenuItem m_tsmiAddGroups = null;

        public override bool Initialize(IPluginHost host_)
        {
            this.host = host_;

            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection tsMenu = this.host.MainWindow.ToolsMenu.DropDownItems;

            // Add a separator at the bottom
            this.m_tsSeparator = new ToolStripSeparator();
            tsMenu.Add(this.m_tsSeparator);

            // Add menu item 'Suggest URL In Title'
            this.m_tsmiAddGroups = new ToolStripMenuItem();
            this.m_tsmiAddGroups.Text = "Suggest &URL In Title";
            this.m_tsmiAddGroups.Click += this.OnRunClicked;
            tsMenu.Add(this.m_tsmiAddGroups);

            return true;
        }

        public override void Terminate()
        {
            // Remove all of our menu items
            ToolStripItemCollection tsMenu = this.host.MainWindow.ToolsMenu.DropDownItems;
            tsMenu.Remove(this.m_tsSeparator);
            tsMenu.Remove(this.m_tsmiAddGroups);
        }

        public void OnRunClicked(object source, System.EventArgs e)
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

            suggestedModifications = changes_form.GetSuggestedModications();

            foreach (SuggestedModification item in suggestedModifications)
            {
                PwEntry entry = this.host.Database.RootGroup.FindEntry(item.Uuid, true);

                entry.Strings.Set(KPRes.Title, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Title).IsProtected, item.NewTitle));
                entry.Strings.Set(KPRes.Url, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Url).IsProtected, item.suggestedUrl));
                entry.LastModificationTime = DateTime.Now;
            }

            this.host.MainWindow.UpdateUI(false, null, true, this.host.Database.RootGroup, true, null, true);
        }

        public static SuggestedModification SuggestModification(string url, string name, PwUuid uuid)
        {
            Uri asUri = new Uri(url);
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
                .RemoveStart("signup.");
            string suggestUrl = asUri.GetLeftPart(UriPartial.Authority);

            if (!string.Equals(name, suggestedName) || !string.Equals(url, suggestUrl))
            {
                return new SuggestedModification()
                {
                    NewTitle = suggestedName, OldTitle = name, OldUrl = url, suggestedUrl = suggestUrl, Uuid = uuid,
                };
            }
            else
            {
                throw new Exception(string.Format("Skipping entry with name: {0} and url: {1}", name, url));
            }
        }
    }

    public struct SuggestedModification
    {
        public string OldTitle;
        public string NewTitle;
        public string OldUrl;
        public string suggestedUrl;
        public PwUuid Uuid;
    }
}