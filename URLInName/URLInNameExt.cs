using System;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Forms;
using KeePass.Resources;

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
            m_tsmiAddGroups.Text = "Suggest URL In Title";
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
                foreach (var i in  this.host.Database.RootGroup.GetEntries (true))
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
                            .Replace("secure.","")
                            .Replace("auth.","")
                            .Replace("ssl.","")
                            .Replace("my.","")
                            .Replace("m.","")
                            .Replace("login.", "");
                        string suggestUrl = asUri.GetLeftPart(UriPartial.Authority);

                        if (!string.Equals(entryName, suggestedName) || !string.Equals(entryURL, suggestUrl))
                        {
                            string formattedText = string.Format("Entry -\n          name: {0,20} \n suggested name: {2,20} \n\n           url: {1,50}\n suggested url: {3,50}\n", entryName, entryURL, suggestedName, suggestUrl);


                            file.WriteLine(formattedText);
                            file.Flush();

                            if (MessageBox.Show(formattedText, "Replace", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                i.Strings.Set(KPRes.Title, new KeePassLib.Security.ProtectedString(i.Strings.Get(KPRes.Title).IsProtected, suggestedName));
                                i.Strings.Set(KPRes.Url, new KeePassLib.Security.ProtectedString(i.Strings.Get(KPRes.Url).IsProtected, suggestUrl));

                                host.MainWindow.UpdateUI(false, null, true, host.Database.RootGroup, true, null, true);
                            }
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
            }
        }

    }

}