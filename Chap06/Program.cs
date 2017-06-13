using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap06 {
    public static class StringBuilderExtensinss {
        public static Int32 IndexOf(this StringBuilder sb, char value) {
            for (int i = 0; i < sb.Length; i++) {
                if (sb[i] == value)
                    return i;
            }
            return -1;
        }

        public static void ShowItem<T>(this IEnumerable<T> collection) {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }
    class Program {
        static void Main(string[] args) {
            //SomeLX lx = new SomeLX();
            //Console.Write(lx.m_x+","+lx.m_s+","+lx.m_d+","+lx.m_b);
            StringBuilder sb = new StringBuilder("zhejaaiubu.cunzaide.");
            Int32 index = sb.Replace('.', '!').IndexOf('!');
            //Console.Write(index);
            //"Grant".ShowItem();
            //new[] { "Jeff", "Kristin" }.ShowItem();
            new List<Int32>() { 1, 2, 3 }.ShowItem();
            Console.Read();
        }
        public sealed class SomeType {
            /// <summary>
            /// 嵌套类
            /// </summary>
            private class SomeNestedType {
            }
            /// <summary>
            /// 常量
            /// </summary>
            private const Int32 C_SomeConstant = 1;
            /// <summary>
            /// 只读
            /// </summary>
            private readonly string M_SomeReadOnlyField = "2";
            /// <summary>
            /// 可读/可写
            /// </summary>
            private static Int32 S_SomeReadWriteField = 3;
            /// <summary>
            /// 类型构造器
            /// </summary>
            static SomeType() { }
            /// <summary>
            /// 实例构造器
            /// </summary>
            /// <param name="x"></param>
            public SomeType(Int32 x) { }
            public SomeType() { }
            /// <summary>
            /// 实例方法
            /// </summary>
            /// <returns></returns>
            private string InstanceMethod() { return null; }
            /// <summary>
            /// 静态方法
            /// </summary>
            //public static void Main() { }
            /// <summary>
            /// 实例属性
            /// </summary>
            public Int32 SompProp { get { return 0; } set { } }
            /// <summary>
            /// 实例有参属性（索引器）
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public Int32 this[string s] { get { return 0; } set { } }

            public event EventHandler SomeEvent;
        }

        internal sealed class SomeLX {
            public Int32 m_x;
            public string m_s;
            public double m_d;
            public byte m_b;


            public SomeLX() {//设置默认值 其他构造器显示调用本构造器
                m_x = 5;
                m_s = "Hi there";
                m_d = 3.14159;
                m_b = 0xff;
            }
            
            public SomeLX(Int32 x) : this() {//其他的都用上面的，M_X用X的值
                m_x = x;
            }

            public SomeLX(string s):this() {//其他值默认M_S用S的值
                m_s = s;
            }

            public SomeLX(Int32 x, string s) : this() {//修改M_X，和M_S的值
                m_x = x;
                m_s = s;
            }
        }
    }
}
