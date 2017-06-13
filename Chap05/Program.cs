using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap05 {
    class Program {
        //class SomeRef { public Int32 x; }

        //struct SomeVal { public Int32 x; }

        //struct Point {
        //    public Int32 x, y;
        //}
        internal struct Point : IComparable {
            private Int32 m_x, m_y;

            /// <summary>
            /// 初始化字段
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Point(Int32 x, Int32 y) {
                m_x = x;
                m_y = y;
            }

            /// <summary>
            /// 将Point作为字符串返回，调用ToString避免装箱
            /// </summary>
            /// <returns></returns>
            public override string ToString() {
                return string.Format("({0},{1})", m_x.ToString(), m_y.ToString());
            }

            /// <summary>
            /// 实现类型安全的CompareTo方法
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public Int32 CompareTo(Point other) {
                return Math.Sign(Math.Sqrt(m_x * m_y + m_y * m_y) - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
            }

            public Int32 CompareTo(object o) {
                if (GetType() != o.GetType()) {
                    throw new ArgumentException("o is not a Point");
                }
                return CompareTo((Point)o);
            }
        }
        static void Main(string[] args) {
            #region MyRegion
            //SomeRef rl = new SomeRef();//堆
            //SomeVal vl = new SomeVal();//栈
            //rl.x = 5;
            //vl.x = 5;

            //ArrayList a = new ArrayList();
            //Point p;
            //for (Int32 i = 0; i < 10; i++) {
            //    p.x = p.y = i;
            //    a.Add(p);
            //}

            ////Int32 x = 5;
            ////Object o = x;
            ////Int16 y = (Int16)(Int32)o;

            //p.x = p.y = 1;
            //Object o = p;
            //p = (Point)o;
            //p.x = 2;
            //o = p;

            var i = 234;
            object obj = i;
            int j = (Int32)obj;
            #endregion


            Console.WriteLine(j);
            Console.Read();

        }
    }
}
