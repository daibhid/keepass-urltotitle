// <copyright file="URLInNameExtTests.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace URLInName.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Test the <see cref="URLInNameExt"/> class.
    /// </summary>
    [TestFixture]
    public class URLInNameExtTests
    {
        /// <summary>
        /// Test the <see cref="URLInNameExt.SuggestModification(string, string, KeePassLib.PwUuid)"/> method.
        /// </summary>
        [Test]
        public void SuggestModificationTest()
        {
            this.TestSuggestion("https://www.somesite.com/about/index.html", "somesite.com", "https://www.somesite.com");
            this.TestSuggestion("twitch.tv", "twitch.tv", "https://twitch.tv");
        }

        private void TestSuggestion(string url, string newName, string newURL)
        {
            SuggestedModification suggestedModification = URLInNameExt.SuggestModification(url, "oldName", null);
            Assert.AreEqual(newName, suggestedModification.NewTitle);
            Assert.AreEqual(newURL, suggestedModification.SuggestedUrl);
        }
    }
}