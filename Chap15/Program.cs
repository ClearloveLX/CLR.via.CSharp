using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
            //MainOne();
            MainTwo();
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

            //Console.WriteLine(Enum.Format(typeof(Color),3,"G"));

            //Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            //Console.WriteLine("Number of symbols defined:"+colors.Length);
            //Console.WriteLine("Value\t Symbol\n-----\t-----");
            //foreach (Color c in colors) {
            //    Console.WriteLine("{0,5:D}\t{0:G}",c);
            //}

            //Color c = (Color)Enum.Parse(typeof(Color), "Orange", true);
            //Color c = (Color)Enum.Parse(typeof(Color), "Brown", true);
            //Enum.TryParse<Color>("1", false, out c);
            //Enum.TryParse<Color>("23", false, out c);

            Console.WriteLine(Enum.IsDefined(typeof(Color), 1));
            Console.WriteLine(Enum.IsDefined(typeof(Color), "White"));
            Console.WriteLine(Enum.IsDefined(typeof(Color), "white"));
            Console.WriteLine(Enum.IsDefined(typeof(Color), 10));
            //Console.WriteLine(c);
        }

        static void MainTwo() {
            //string file = Assembly.GetEntryAssembly().Location;
            //FileAttributes attributes = File.GetAttributes(file);
            //Console.WriteLine("Is {0} hidden? {1}",file,(attributes & FileAttributes.Hidden)!=0);
            Actions actions = Actions.Read | Actions.Delete;
            Console.WriteLine(actions.ToString("F"));
        }

        [Flags, Serializable]
        public enum FileAttributes {
            ReadOnly = 0x0001,
            Hidden = 0x0002,
            System = 0x0004,
            Directory = 0x0010,
            Archive = 0x0020,
            Device = 0x0040,
            Normal = 0x0080,
            Temporary = 0x0100,
            SparseFile = 0x0200,
            ReparsePoint = 0x0400,
            Compressed = 0x0800,
            Offline = 0x1000,
            NotContentIndexed = 0x2000,
            Encrypted = 0x4000,
            IntegrityStream = 0x08000,
            NoScrubData = 0x20000
        }

        [Flags]
        internal enum Actions {
            Read = 0x0001,
            Write = 0x0002,
            ReadWrite = Actions.Read | Actions.Write,
            Delete = 0x0004,
            Query = 0x0008,
            Sync = 0x0010
        }
    }
}
