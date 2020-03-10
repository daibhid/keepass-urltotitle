namespace ConsoleApp1
{
using System;
using System.Collections.Generic;
    using KeePassLib;
using URLInName;

    class Program
    {
        static void Main(string[] args)
        {
            //TestUI();
            TestSuggestions();
        }

        static void TestUI()
        {
            CheckboxTableForm form = new CheckboxTableForm();

            List<SuggestedModification> data = new List<SuggestedModification>
            {
                new SuggestedModification() { NewTitle = "newtitle", OldTitle = "oldtitle", OldUrl = "url", suggestedUrl = "newurl", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "newtitle2", OldTitle = "oldtitle2", OldUrl = "url2", suggestedUrl = "newurl2", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "oldtitle3", OldTitle = "oldtitle3", OldUrl = "url3", suggestedUrl = "newurl3", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "newtitle4", OldTitle = "oldtitle4", OldUrl = "url4", suggestedUrl = "url4", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "oldtitle5", OldTitle = "oldtitle5", OldUrl = "url5", suggestedUrl = "url5", Uuid = new PwUuid(true) },
            };

            form.AddData(data);

            form.ShowDialog();

            List<SuggestedModification> changes = form.GetSuggestedModications();

            Console.WriteLine(string.Format("{0} checked modifications", changes.Count));
        }

        static void TestSuggestions()
        {
            CheckboxTableForm form = new CheckboxTableForm();

            List<SuggestedModification> data = new List<SuggestedModification>
            {
                URLInNameExt.SuggestModification("http://www.instagram.com", "Instagram", new PwUuid(true)),
                URLInNameExt.SuggestModification("http://m.website.com", "website", new PwUuid(true)),
                URLInNameExt.SuggestModification("http://www.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://account.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://accounts.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://signin.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://secure.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://auth.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://ssl.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://my.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://m.site.com", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://login.site.com", string.Empty, new PwUuid(true)),
            };

            form.AddData(data);

            form.ShowDialog();

            List<SuggestedModification> changes = form.GetSuggestedModications();

            Console.WriteLine(string.Format("{0} checked modifications", changes.Count));
        }
    }
}
