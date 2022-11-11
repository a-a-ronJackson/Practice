using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        /// <summary>
        /// Inserts spaces before each capital letter of a string
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string InsertSpaces(this string sourceString)
        {
            string resultString = string.Empty;

            if (!String.IsNullOrWhiteSpace(sourceString))
            {
                foreach (char letter in sourceString)
                {
                    if (char.IsUpper(letter))
                    {
                        resultString = resultString.Trim();
                        resultString += " ";
                    }
                    resultString += letter;
                } 
            }
            resultString = resultString.Trim();
            return resultString;
        }
    }
}
