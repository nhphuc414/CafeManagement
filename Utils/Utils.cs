using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Utils
    {
        public static string NormalizeString(string str)
        {
            if (str == null)
            {
                return null;
            }
            str = str.Trim();
            str=str.ToLower();
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words);
        }
        public static string NormalizeStringName(string str)
        {
            if (str == null)
            {
                return null;
            }
            else
            {
                str = str.Trim();
                str = str.ToLower();
                string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].ToLower();
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
                return string.Join(" ", words);
            }
        }
    }
}
