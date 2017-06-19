using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap14 {
    class Program {
        static void Main(string[] args) {
            //MainOne();
            MainTwo();

            Console.Read();
        }

        #region 第十四章第1节---字符
        static void MainOne() {
            double d;
            //d = char.GetNumericValue('\u0033');/3
            //d = char.GetNumericValue('\u00bc');/0.25/1/4
            //d = char.GetNumericValue('A');/错误值，返回-1

            char c;
            int n;
            c = (char)65;
            Console.WriteLine(c);
            n = (int)c;
            Console.WriteLine(n);
            c = unchecked((char)(65536 + 65));
            Console.WriteLine(c);

            c = Convert.ToChar(65);
            Console.WriteLine(c);
            n = Convert.ToInt32(c);
            Console.WriteLine(n);

            try {
                c = Convert.ToChar(66);
                Console.WriteLine(c);
            }
            catch (Exception) {
                Console.WriteLine("Can't convert 70000 to a Char");
            }
            c = ((IConvertible)65).ToChar(null);
            Console.WriteLine(c);
            n = ((IConvertible)c).ToInt32(null);
            Console.WriteLine(n);
        }
        #endregion

        static void MainTwo() {
            //string s = "Hi"+" 300".ToUpperInvariant();

            //string s1 = "Strasse";
            //string s2 = "Straße";
            //bool eq;
            //eq = string.Compare(s1, s2, StringComparison.Ordinal) == 0;
            //Console.WriteLine("'{0}' '{2}' '{1}'", s1, s2, eq ? "==" : "!=");

            //CultureInfo ci = new CultureInfo("de-DE");
            //eq = string.Compare(s1, s2, true, ci) == 0;
            //Console.WriteLine("'{0}' '{2}' '{1}'", s1, s2, eq ? "==" : "!=");

            string output = string.Empty;
            string[] symbol = new string[] { "<", "=", ">" };
            int x;
            CultureInfo c1;

        }
    }
}
