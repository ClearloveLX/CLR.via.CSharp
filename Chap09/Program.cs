using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chap09 {
    sealed class Classroom {
        private List<string> m_students = new List<string>();
        public List<string> Students { get { return m_students; } }
        public Classroom() { }
    }
    internal sealed class SomeType {
        public Int32 m_val;
    }
    static class Program {
        static void Main(string[] args) {
            #region MyRegion
            //M(3,"sa",guid: Guid.NewGuid());
            //var x = "fdsafd4545";
            //var y = new  System.Data.DataTable();

            //Int32 x = 5;
            //GetVal(out x);
            //string s1 = "gaoke";
            //string s2 = "clearlovelx";
            //object o1 = s1, o2 = s2;
            //Swap(ref s1, ref s1);

            //Console.WriteLine(o1);
            //Console.WriteLine(o2);
            //SomeType st;
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //DisplayTypes(new object(),new System.Data.DataTable(),new Random(),"gaoke",5);
            //Classroom classroom = new Classroom { Students = {
            //        "clearlove","clearlovelx","gaoke"
            //    } };

            //foreach (var student in classroom.Students) {
            //    Console.WriteLine(student);
            //}

            //var o1 = new { Name = "clearlovelx", Age = 1995 };
            //var people = new[] { o1,
            //new {Name = "Kri" ,Age=1970 },
            //new {Name = "Aid" ,Age=1870 },
            //new {Name = "Grant" ,Age=2070 },
            //};
            ////Console.WriteLine("Name={0},Age={1}", o1.Name, o1.Age);
            //foreach (var person in people) {
            //    Console.WriteLine("People={0},Age={1}", person.Name, person.Age);
            //}
            //var minmax = MinMax(6, 2);
            //Console.WriteLine("Min={0},Max={1}", minmax.Item1, minmax.Item2);
            //var tuple = Tuple.Create(0, 1, 2, 3, 4, 5, 6, Tuple.Create(7, 8, 9, 10));
            //Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Rest.Item1.Item1, tuple.Rest.Item1.Item2, tuple.Rest.Item1.Item3, tuple.Rest.Item1.Item4);
            //dynamic e = new System.Dynamic.ExpandoObject();
            //e.x = 6;
            //e.y = "gaoke";
            //e.z = null;
            //foreach (var v in (IDictionary<string, object>)e) {
            //    Console.WriteLine("Key = {0} Val = {1}", v.Key, v.Value);
            //}
            //var d = (IDictionary<string, object>)e;
            //d.Remove("x");
            //d.Remove("y");
            //foreach (var v in (IDictionary<string, object>)e) {
            //    Console.WriteLine("Key = {0} Val = {1}", v.Key, v.Value);
            //}
            #endregion
            BitArray ba = new BitArray(14);
            for (int x = 0; x < 14; x++) {
                ba[x] = (x % 2 == 0);
            }
            for (int x = 0; x < 14; x++) {
                Console.WriteLine("Bit "+x+" is " + (ba[x] ? "ON" : "Off"));
            }
            Console.Read();
        }

        public sealed class BitArray {
            private byte[] m_byteArray;
            private int m_numBits;

            public BitArray(int numBits) {
                if (numBits < 0) {
                    throw new ArgumentOutOfRangeException("numBits must be > 0");
                }
                m_numBits = numBits;
                m_byteArray = new byte[(numBits + 7) / 8];
            }

            public bool this[int bitPos] {
                get {
                    if ((bitPos < 0) || (bitPos >= m_numBits)) {
                        throw new ArgumentOutOfRangeException("bitPos");
                    }
                    return (m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
                }

                set {
                    if ((bitPos < 0) || (bitPos >= m_numBits)) {
                        throw new ArgumentOutOfRangeException("bitPos", bitPos.ToString());
                    }
                    if (value) {
                        m_byteArray[bitPos / 8] = (byte)(m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
                    }
                    else {
                        m_byteArray[bitPos / 8] = (byte)(m_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
                    }
                }
            }
        }


        private static Tuple<Int32, Int32> MinMax(Int32 a, Int32 b) {
            return Tuple.Create(Math.Min(a, b), Math.Max(a, b));
        }

        private static void DisplayTypes(params object[] objects) {
            if (objects != null) {
                foreach (object o in objects) {
                    Console.WriteLine(o.GetType());
                }
            }
        }

        private static void GetAnObject(out object o) {
            o = new string('X', 100);
        }

        private static void Swap<T>(ref T a, ref T b) {
            T t = b;
            b = a;
            a = t;
        }

        private static Int32 s_n = 0;

        private static void M(Int32 x = 9, string s = "A", DateTime dt = default(DateTime), Guid guid = new Guid()) {
            Console.WriteLine("X={0},S={1},dt={2},guid={3}", x, s, dt, guid);
        }

        private static object ShowVariableType(this object val) {
            return val.GetType();
        }

        private static void GetVal(out Int32 v) {
            v = 10;
        }

        private static void AddVal(ref Int32 v) {
            v += 10;
        }
    }
}
