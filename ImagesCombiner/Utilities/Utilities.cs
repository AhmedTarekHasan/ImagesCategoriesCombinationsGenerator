using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentSimplyPut.Utilities
{
    public static class Utilities
    {
        /// <summary>
        /// Splits a string into two parts, the first one is the string part before the last existance of a certain character,
        /// the second one is the string part after the last existance of the same character
        /// </summary>
        /// <param name="source"></param>
        /// <param name="splitAtChar"></param>
        /// <returns></returns>
        public static string[] ext_SplitAtLastCharExistance(this string source, char splitAtChar)
        {
            string[] result = { string.Empty, string.Empty };
            if (string.IsNullOrEmpty(source))
            {
                //string is empty
                return result;
            }

            if (!(source.Contains(splitAtChar)))
            {
                //character doesn't exist in the string
                result[0] = source;
                return result;
            }

            if (source.Length == 1)
            {
                //the string is only the character itself
                return result;
            }

            int temp = source.LastIndexOf(splitAtChar);

            if (temp == 0)
            {
                //the character is at the start
                result[0] = string.Empty;
                result[1] = source.Substring(temp + 1, source.Length - temp - 1);
            }
            else if (temp == source.Length - 1)
            {
                //the character is at the end
                result[0] = source.Substring(0, temp);
                result[1] = string.Empty;
            }
            else
            {
                //the character is in the middle
                result[0] = source.Substring(0, temp);
                result[1] = source.Substring(temp + 1, source.Length - temp - 1);
            }

            return result;
        }
    }
}
