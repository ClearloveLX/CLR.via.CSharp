using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeList = System.Collections.Generic.List<System.DateTime>;

namespace Chap12 {
    #region MyRegion
    internal sealed class DictionaryStringKey<TValue> : Dictionary<string, TValue> { }

    internal class Node {
        protected Node m_next;
        public Node(Node next) {
            m_next = next;
        }
    }

    internal class TypeNode<T> : Node {
        public T m_data;
        public TypeNode(T data) : this(data, null) {
        }
        public TypeNode(T data, Node next) : base(next) {
            m_data = data;
        }

        public override string ToString() {
            return m_data.ToString() + ((m_next != null) ? m_next.ToString() : string.Empty);
        }
    }
    #endregion
    public class GenericType<T> {
        private T m_value;
        public GenericType(T value) {
            m_value = value;
        }
        public TOutput Converter<TOutput>() {
            TOutput result = (TOutput)Convert.ChangeType(m_value, typeof(TOutput));
            return result;
        }
    }
    class Program {
        static void Main(string[] args) {
            #region MyRegion
            //ValueTypePerfTest();
            //ReferenceTypePerfTest();

            //byte[] byteArray = new byte[] { 5, 1, 4, 2, 3 };
            //Array.Sort<byte>(byteArray);
            //int i = Array.BinarySearch<byte>(byteArray, 1);
            //Console.WriteLine(i);

            //object o = null;
            //Type t = typeof(Dictionary<,>);
            //o = CreateInstance(t);
            //Console.WriteLine();
            //t = typeof(DictionaryStringKey<Guid>);
            //o = CreateInstance(t);
            //Console.WriteLine("对象类型=" + o.GetType());

            //DifferentDataLinkedList(); 
            #endregion
            //CallingSwap();
            GenericType<string> gt = new GenericType<string>("4577dsfasa564");
            Console.WriteLine(gt.Converter<string>());
            Console.Read();
        }

        private static void Display(string s) {
            Console.WriteLine(s);
        }

        private static void Display<T>(T o) {

        }

        private static void Swap<T>(ref T o1, ref T o2) {
            T temp = o1;
            o1 = o2;
            o2 = temp;
        }

        private static void CallingSwap() {
            int n1 = 1, n2 = 2;
            Console.WriteLine("n1={0},n2={1}", n1, n2);
            Swap<int>(ref n1, ref n2);
            Console.WriteLine("n1={0},n2={1}", n1, n2);

            string s1 = "ClearloveLX", s2 = "gaoke";
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("s1={0},s2={1}", s1, s2);
        }

        #region MyRegion
        internal sealed class SomeType {
            private static void SomeMethod() {
                var dt1 = new List<DateTime>();
                Console.WriteLine(dt1.GetType());
            }
        }

        private static void DifferentDataLinkedList() {
            Node head = new TypeNode<char>('.');
            head = new TypeNode<DateTime>(DateTime.Now, head);
            head = new TypeNode<string>("Today is ", head);
            Console.WriteLine(head.ToString());
        }

        private static object CreateInstance(Type t) {
            object o = null;
            try {
                o = Activator.CreateInstance(t);
                Console.Write("已创建{0}的实例。", t.ToString());
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            return o;
        }

        private static void ValueTypePerfTest() {
            const int count = 100000000;
            using (new OperationTimer("List<int>")) {
                List<int> i = new List<int>();
                for (int n = 0; n < count; n++) {
                    i.Add(n);//不发生装箱
                    int x = i[n];//不发生拆箱
                }
                i = null;//确保进行垃圾回收
            }
            using (new OperationTimer("ArrayList of int")) {
                ArrayList a = new ArrayList();
                for (int n = 0; n < count; n++) {
                    a.Add(n);//装箱
                    int x = (int)a[n];//拆箱
                }
                a = null;
            }
        }

        private static void ReferenceTypePerfTest() {
            const int count = 100000000;
            using (new OperationTimer("List<string>")) {
                List<string> s = new List<string>();
                for (int n = 0; n < count; n++) {
                    s.Add("X");//复制引用
                    string x = s[n];//复制引用
                }
                s = null;
            }
            using (new OperationTimer("ArrayList of string")) {
                ArrayList a = new ArrayList();
                for (int n = 0; n < count; n++) {
                    a.Add("X");//复制引用
                    string x = (string)a[n];//检查强制类型转换&复制引用
                }
                a = null;
            }
        }

        internal sealed class OperationTimer : IDisposable {
            private Stopwatch m_stopwatch;
            private string m_text;
            private int m_collectionCount;

            public OperationTimer(string text) {
                PrepareForOperation();
                m_text = text;
                m_collectionCount = GC.CollectionCount(0);
                m_stopwatch = Stopwatch.StartNew();
            }

            public void Dispose() {
                Console.WriteLine("{0} (GCs={1,3}){2}", (m_stopwatch.Elapsed), GC.CollectionCount(0) - m_collectionCount, m_text);
            }

            private static void PrepareForOperation() {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
        private static void SomeMethod() {
            List<DateTime> dtList = new List<DateTime>();

            dtList.Add(DateTime.Now);
            dtList.Add(DateTime.MinValue);
            //dtList.Add("1/1/2004");
            DateTime dt = dtList[0];
        }
        #endregion
    }
}
