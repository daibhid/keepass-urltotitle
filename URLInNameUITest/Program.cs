// <copyright file="Program.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using KeePassLib;
    using URLInName;

    /// <summary>
    /// Test application to show the UI for testing.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main which shows the UI.
        /// </summary>
        /// <param name="args">Arguments ignored.</param>
        internal static void Main(string[] args)
        {
            ////TestUI();
            TestSuggestions();
        }

        /// <summary>
        /// Test the UI by displaying UI (does no inputu suggestions.)
        /// </summary>
        internal static void TestUI()
        {
            CheckboxTableForm form = new CheckboxTableForm();

            List<SuggestedModification> data = new List<SuggestedModification>
            {
                new SuggestedModification() { NewTitle = "newtitle", OldTitle = "oldtitle", OldUrl = "url", SuggestedUrl = "newurl", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "newtitle2", OldTitle = "oldtitle2", OldUrl = "url2", SuggestedUrl = "newurl2", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "oldtitle3", OldTitle = "oldtitle3", OldUrl = "url3", SuggestedUrl = "newurl3", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "newtitle4", OldTitle = "oldtitle4", OldUrl = "url4", SuggestedUrl = "url4", Uuid = new PwUuid(true) },
                new SuggestedModification() { NewTitle = "oldtitle5", OldTitle = "oldtitle5", OldUrl = "url5", SuggestedUrl = "url5", Uuid = new PwUuid(true) },
            };

            form.AddData(data);

            form.ShowDialog();

            List<SuggestedModification> changes = form.SuggestedModifications;

            Console.WriteLine(string.Format("{0} checked modifications", changes.Count));
        }

        /// <summary>
        /// Test the suggestion algorithm, by running a fex examples.
        /// </summary>
        internal static void TestSuggestions()
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

                URLInNameExt.SuggestModification("http://login.site.com/", string.Empty, new PwUuid(true)),
                URLInNameExt.SuggestModification("http://login.site.com/auth/html.com/https://login.site.com", string.Empty, new PwUuid(true)),

                URLInNameExt.SuggestModification("twitch.tv", string.Empty, new PwUuid(true)),
            };

            form.AddData(data);

            form.ShowDialog();

            List<SuggestedModification> changes = form.SuggestedModifications;

            Console.WriteLine(string.Format("{0} checked modifications", changes.Count));
        }
    }
}
