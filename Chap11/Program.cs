using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chap11 {
    #region 第一步
    //定义类型来容纳所有需要发送给事件通知接受者的附加信息
    internal class NewMailEventArgs : EventArgs {
        private readonly string m_from, m_to, m_subject;
        public NewMailEventArgs(string from, string to, string subject) {
            m_from = from; m_to = to; m_subject = subject;
        }
        public string From { get { return m_from; } }
        public string To { get { return m_to; } }
        public string Subject { get { return m_subject; } }
    }
    #endregion

    internal class MailManager {
        #region 第二步
        //定义事件成员
        public event EventHandler<NewMailEventArgs> NewMail;
        #endregion
        #region 第三步
        //定义负责引发事件的方法来通知已登记的对象，如果类是密封的，该方法要声明为私有非虚
        protected virtual void OnNewMail(NewMailEventArgs e) {
            //e.Raise(this, ref m_NewMail);
        }
        #endregion
    }

    public static class EventArgExtensions {
        public static void Raise<TEventArge>(this TEventArge e, object sender, ref EventHandler<TEventArge> eventDelegate) {
            EventHandler<TEventArge> temp = Volatile.Read(ref eventDelegate);
            if (temp != null) temp(sender, e);
        }
       
    }

    class Program {
        static void Main(string[] args) {
        }
    }
}
