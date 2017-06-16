using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap13 {
    public sealed class Point : IComparable<Point> {
        private int m_x, m_y;
        public Point(int x, int y) {
            m_x = x;
            m_y = y;
        }

        public int CompareTo(Point other) {
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y) - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }

        public override string ToString() {
            return string.Format("({0},{1})", m_x, m_y);
        }
    }


    internal class Base : IDisposable {
        public void Dispose() {
            Console.WriteLine("Base's Dispose");
        }
    }
    internal class Derived : Base, IDisposable {
        new public void Dispose() {
            Console.WriteLine("Derived's Dispose");
        }
    }

    internal sealed class SimpleType : IDisposable {
        public void Dispose() {
            Console.WriteLine("Dispose");
        }
        void IDisposable.Dispose() {
            Console.WriteLine("IDisposable Dispose");
        }
    }

    public sealed class Number : IComparable<int>, IComparable<string> {
        private int m_val = 5;
        /// <summary>
        /// 实现IComparable<int>的CompareTo
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CompareTo(int n) {
            return m_val.CompareTo(n);
        }

        public int CompareTo(string s) {
            return m_val.CompareTo(int.Parse(s));
        }
    }

    class Program {
        static void Main(string[] args) {
            #region 1
            //Point[] points = new Point[] {
            //    new Point (3,3),
            //    new Point (1,2)
            //};
            //if (points[0].CompareTo(points[1]) > 0) {
            //    Point tempPoint = points[0];
            //    points[0] = points[1];
            //    points[1] = tempPoint;
            //}
            //Console.WriteLine("Points from Closest to (0,0) to farthest:");

            //foreach (Point p in points) {
            //    Console.WriteLine(p);
            //} 
            #endregion
            #region 2
            //Base b = new Base();
            //b.Dispose();
            //Derived d = new Derived();
            //d.Dispose();
            //((IDisposable)d).Dispose();
            //b = new Derived();
            //b.Dispose();
            //((IDisposable)b).Dispose();
            #endregion
            #region 3
            //string s = "Jeffrey";
            //ICloneable cloneable = s;
            //IComparable comparable = s;
            //IEnumerable enumerable = (IEnumerable)comparable;
            //Console.WriteLine("{0},{1},{2},{3}", s, cloneable, comparable, enumerable); 
            #endregion
            #region 4
            //SimpleType st = new SimpleType();
            //st.Dispose();
            //IDisposable d = st;
            //d.Dispose(); 
            #endregion
            Number n = new Number();
            //将n和int(5)的值比较
            IComparable<int> cInt = n;
            int result = cInt.CompareTo(284);

            IComparable<string> cString = n;
            result = cString.CompareTo("5");
            Console.Read();
        }

        private void SomeMethod1() {
            int x = 1, y = 2;
            IComparable c = x;
            c.CompareTo(y);//在这装箱
            c.CompareTo("2");
        }
        private void SomeMethod2() {
            int x = 1, y = 2;
            IComparable<int> c = x;
            c.CompareTo(y);//在这不装箱
            c.CompareTo(2);
        }
    }
}
