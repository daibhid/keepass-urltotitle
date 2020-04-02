// <copyright file="ExtensionMethods.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace URLInName
{
    using System.Drawing;

    /// <summary>
    /// Extension methods for the plugin.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Makes a font into a bold font.
        /// </summary>
        /// <param name="font">The font to enbolden.</param>
        /// <returns>The input font, with the bold style set.</returns>
        public static Font SetBold(this Font font)
        {
            return new Font(font, FontStyle.Bold);
        }

        /// <summary>
        /// Removes a certain prefix from a string if it exists.
        /// </summary>
        /// <param name="source">The string to modify.</param>
        /// <param name="remove">The prefix to remove.</param>
        /// <returns>The modified string.</returns>
        public static string RemoveStart(this string source, string remove)
        {
            if (source.StartsWith(remove))
            {
                return source.Substring(remove.Length);
            }
            else
            {
                return source;
            }
        }
    }
}
