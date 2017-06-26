using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap15 {
    internal enum Color : byte {
        White,
        Red,
        Green,
        Blue,
        Orange
    }
    class Program {
        static void Main(string[] args) {
            MainOne();
            Console.Read();
        }
        static void MainOne() {
            //Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));

            //Color c = Color.Blue;
            //Console.WriteLine(c);
            //Console.WriteLine(c.ToString());
            //Console.WriteLine(c.ToString("G"));
            //Console.WriteLine(c.ToString("D"));
            //Console.WriteLine(c.ToString("X"));

            Console.WriteLine(Enum.Format(typeof(Color),3,"G"));
        }
    }
}
