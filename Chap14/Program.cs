using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chap14 {
    class Program {
        static void Main(string[] args) {
            //MainOne();
            //MainTwo();
            MainThree();
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

        #region 第十四章第2~4节
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

            //string s1 = "Hello";
            //string s2 = "Hello";
            //Console.WriteLine(object.ReferenceEquals(s1, s2));
            //s1 = string.Intern(s1);
            //s2 = string.Intern(s2);
            //Console.WriteLine(object.ReferenceEquals(s1, s2));

            //string s = "a\u0304\u0308bc\u0327";
            //SubstringByTextElements(s);
            //EnumTextElements(s);
            //EnumTextElementIndexes(s);

            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").Replace(" ", "-");

            //string s = sb.ToString().ToUpper();
            //sb.Length = 0;
            //sb.Append(s).Insert(8, "双击666");
            //s = sb.ToString();
            //Console.WriteLine(s);

            //decimal price = 123.54M;
            //string s = price.ToString("C", CultureInfo.InvariantCulture);
            //MessageBox.Show(s);

            string s = string.Format("On {0},{1} is {2} years old.", new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
            Console.WriteLine(s);
        }

        static void SubstringByTextElements(string s) {
            string output = string.Empty;
            StringInfo si = new StringInfo(s);
            for (int element = 0; element < si.LengthInTextElements; element++) {
                output += string.Format("Text element{0} is '{1}' {2}", element, si.SubstringByTextElements(element, 1), Environment.NewLine);
            }
            MessageBox.Show(output, "Result of SubstringByTextElements");
        }

        static void EnumTextElements(string s) {
            string output = string.Empty;
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);
            while (charEnum.MoveNext()) {
                output += string.Format("Character at index{0} is '{1}' {2}", charEnum.ElementIndex, charEnum.GetTextElement(), Environment.NewLine);
            }
            MessageBox.Show(output, "Result of GetTextElementEnumerator");
        }

        static void EnumTextElementIndexes(string s) {
            string output = string.Empty;
            int[] textElemIndex = StringInfo.ParseCombiningCharacters(s);
            for (int i = 0; i < textElemIndex.Length; i++) {
                output += string.Format("Character {0} starts at index{1}{2}", i, textElemIndex[i], Environment.NewLine);
            }
            MessageBox.Show(output, "Result of ParseCombiningCharacters");
        }
        #endregion

        static void MainThree() {
            //int x = int.Parse("1A", NumberStyles.HexNumber, null);
            //string s = "Hi there.";
            //Encoding encodingUTF8 = Encoding.UTF8;
            //byte[] encodedBytes = encodingUTF8.GetBytes(s);
            //Console.WriteLine("Encoded Bytes:" + BitConverter.ToString(encodedBytes));
            //string decodedString = encodingUTF8.GetString(encodedBytes);
            //Console.WriteLine("Decoded string:" + decodedString);

            byte[] bytes = new byte[10];
            new Random().NextBytes(bytes);
            string s = Convert.ToBase64String(bytes);
            Console.WriteLine(s);
            bytes = Convert.FromBase64String(s);
            Console.WriteLine(BitConverter.ToString(bytes));
        }
    }
}
