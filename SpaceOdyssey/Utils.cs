using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Utils
    {
        public static char[][] StringToCharArray2D(String str)
        {
            String[] strArray = str.Split(Environment.NewLine);
            char[][] chars = new char[strArray.Length][];
            for (int i = 0; i < strArray.Length; i++)
            {
                char[] row = new char[strArray[i].Length];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = strArray[i][j];
                }
                chars[i] = row;
            }
            return chars;
        }
    }
}
