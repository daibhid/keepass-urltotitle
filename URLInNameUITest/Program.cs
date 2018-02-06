using KeePassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLInName;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckboxTableForm form = new CheckboxTableForm();

            var data = new List<SuggestedModification>
            {
                new SuggestedModification(){ NewTitle = "newtitle", OldTitle = "oldtitle", OldUrl = "url", suggestedUrl = "newurl", Uuid = new PwUuid(true) },
                new SuggestedModification(){ NewTitle = "newtitle2", OldTitle = "oldtitle2", OldUrl = "url2", suggestedUrl = "newurl2", Uuid = new PwUuid(true) },
                new SuggestedModification(){ NewTitle = "oldtitle3", OldTitle = "oldtitle3", OldUrl = "url3", suggestedUrl = "newurl3", Uuid = new PwUuid(true) },
                new SuggestedModification(){ NewTitle = "newtitle4", OldTitle = "oldtitle4", OldUrl = "url4", suggestedUrl = "url4", Uuid = new PwUuid(true) },
                new SuggestedModification(){ NewTitle = "oldtitle5", OldTitle = "oldtitle5", OldUrl = "url5", suggestedUrl = "url5", Uuid = new PwUuid(true) }
            };

            form.AddData(data);

            form.ShowDialog();

            var changes = form.GetSuggestedModications();

            Console.WriteLine(string.Format("{0} checked modifications", changes.Count));

        }
    }
}
