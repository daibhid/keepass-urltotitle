using System;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Forms;
using KeePass.Resources;
using System.Collections.Generic;
using KeePassLib;

namespace URLInName
{
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
            m_tsSeparator = new ToolStripSeparator();
            tsMenu.Add(m_tsSeparator);

            // Add menu item 'Suggest URL In Title'
            m_tsmiAddGroups = new ToolStripMenuItem();
            m_tsmiAddGroups.Text = "Suggest &URL In Title";
            m_tsmiAddGroups.Click += OnRunClicked;
            tsMenu.Add(m_tsmiAddGroups);

            return true;
        }

        public override void Terminate()
        {
            // Remove all of our menu items
            ToolStripItemCollection tsMenu = host.MainWindow.ToolsMenu.DropDownItems;
            tsMenu.Remove(m_tsSeparator);
            tsMenu.Remove(m_tsmiAddGroups);
        }

        public void OnRunClicked(object source, System.EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/home/dave/Desktop/keepass_entries.txt"))
            {
                List<SuggestedModification> suggestedModifications = new List<SuggestedModification>();

                foreach (var i in this.host.Database.RootGroup.GetEntries(true))
                {
                    var entryName = i.Strings.Get(KPRes.Title).ReadString();
                    var entryURL = i.Strings.Get(KPRes.Url).ReadString();

                    try
                    {
                        Uri asUri = new Uri(entryURL);
                        string suggestedName = asUri.Host.Replace("www.", "")
                            .Replace("account.", "")
                            .Replace("accounts.", "")
                            .Replace("signin.", "")
                            .Replace("secure.", "")
                            .Replace("auth.", "")
                            .Replace("ssl.", "")
                            .Replace("my.", "")
                            .Replace("m.", "")
                            .Replace("login.", "");
                        string suggestUrl = asUri.GetLeftPart(UriPartial.Authority);

                        if (!string.Equals(entryName, suggestedName) || !string.Equals(entryURL, suggestUrl))
                        {
                            suggestedModifications.Add(new SuggestedModification()
                                {
                                    NewTitle = suggestedName, OldTitle = entryName, OldUrl = entryURL, suggestedUrl = suggestUrl, Uuid = i.Uuid
                                });

                            //string formattedText = string.Format("Entry -\n          name: {0,20} \n suggested name: {2,20} \n\n           url: {1,50}\n suggested url: {3,50}\n", entryName, entryURL, suggestedName, suggestUrl);

                            //file.WriteLine(formattedText);
                            //file.Flush();

                            //if (MessageBox.Show(formattedText, "Replace", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            //{
                            //}
                        }
                        else
                        {
                            file.WriteLine(string.Format("Skipping entry with name: {0} and url: {1}", entryName, entryURL));
                            file.Flush();
                        }

                    }
                    catch (Exception ex)
                    {
                        file.WriteLine(string.Format("For URL:{0}, exception:{1}", entryURL, ex.ToString()));
                        file.Flush();
                    }

                }

                CheckboxTableForm changes_form = new CheckboxTableForm();
                changes_form.AddData(suggestedModifications);
                changes_form.ShowDialog();

                suggestedModifications = changes_form.GetSuggestedModications();
            

                foreach (var item in suggestedModifications)
                {
                    var entry = this.host.Database.RootGroup.FindEntry(item.Uuid, true);

                    entry.Strings.Set(KPRes.Title, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Title).IsProtected, item.NewTitle));
                    entry.Strings.Set(KPRes.Url, new KeePassLib.Security.ProtectedString(entry.Strings.Get(KPRes.Url).IsProtected, item.suggestedUrl));
                    entry.LastModificationTime = DateTime.Now;
                }

                host.MainWindow.UpdateUI(false, null, true, host.Database.RootGroup, true, null, true);
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