using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLInName
{
    static class ExtensionMethods
    {
        public static Font SetBold(this Font font)
        {
            return new Font(font, FontStyle.Bold);
        }

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
