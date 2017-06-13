using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft;

namespace Chap04 {
   sealed  class Program {
        internal class Employee {
            public Int32 GetYearEmployee (){ return 123; }
            public virtual String GetProgressReport (){ return null; }
            public static Employee Lookup(String name) { return null; }
        }

        internal sealed class Manager : Employee {
            public override string GetProgressReport() {
                return base.GetProgressReport();
            }
        }

        internal class B { //基类

        }

        internal class D : B { //派生类

        }
        static void Main(string[] args) {
            //string mode = "mode";
            //FileStream fs = new FileStream(@"D:\233", FileMode.Open);
            //StringBuilder sb = new StringBuilder();
            Byte b = 100;
            b = checked((Byte)(b + 200));
            UInt32 inval = unchecked((UInt32)(-1));
            Console.WriteLine(b);
            Console.Read();
        }
    }
}
