using Chap13;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chap16 {
    class Program {
        static void Main(string[] args) {
            MethodOne();

            Console.Read();
        }

        static void MethodOne() {
            //Control[] myContrpls;
            //myContrpls = new Control[50];
            //Console.WriteLine(myContrpls.Length);

            //string[] names = new string[] { "Aidan", "GRant" };

            //var kids = new[] { new { Name = "Aidan" }, new { Name = "Grant" } };

            //foreach (var kid in kids) {
            //    Console.WriteLine(kid.Name);
            //}

            FileStream[,] fs2dim = new FileStream[5, 10];

            object[,] o2dim = fs2dim;

            Stream[,] s2dim = (Stream[,])o2dim;
        }
    }
}
