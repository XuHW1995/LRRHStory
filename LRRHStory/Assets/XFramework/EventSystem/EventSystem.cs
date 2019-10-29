//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace XFramework
//{
//    public delegate void EventHander(EventId eventenum, params object[] param);

//    public static class EventSystem
//    {
//        private static Dictionary<EventId, EventCollection> m_AllListenerMap;

//        /// <summary>
//        /// 注册监听
//        /// </summary>
//        /// <param name="eventId"></param>
//        /// <param name="eventHander"></param>
//        public static void RegisterEvent(EventId eventId, EventHander eventHander)
//        {
//            EventCollection eventCollection;
//            if (m_AllListenerMap.TryGetValue(eventId, out eventCollection))
//            {
//                eventCollection.Add(eventHander);
//                return;
//            }

//            eventCollection = new EventCollection();
//            eventCollection.Add(eventHander);
//            m_AllListenerMap.Add(eventId, eventCollection);
//        }

//        /// <summary>
//        /// 注销监听
//        /// </summary>
//        /// <param name="eventId"></param>
//        public static void UnregisterEvent(EventId eventId)
//        {
//            EventCollection eventCollection;
//            if (m_AllListenerMap.TryGetValue(eventId, out eventCollection))
//            {
//                eventCollection.Remove();
//            }
//        }

//        /// <summary>
//        /// 触发事件
//        /// </summary>
//        public static void SendEvent()
//        {

//        }

//        private class EventCollection
//        {
//            List<EventHander> m_handerList;

//            public void Add(EventHander hander)
//            {

//            }

//            public void Remove()
//            {

//            }

//            public void Fire()
//            {

//            }
//        }
//    }
//}
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XFramework
{
    public delegate void OnEvent(int key, params object[] param);

    // 弱引用事件
    // http://blog.csdn.net/hulihui/article/details/3217649
    public static class BaseEventSystem
    {
        static Dictionary<int, ListenerWrap> m_AllListenerMap = new Dictionary<int, ListenerWrap>(50);

        public static bool Register<T>(T key, OnEvent fun) where T : IConvertible
        {
            int kv = key.ToInt32(null);
            ListenerWrap wrap;
            if (!m_AllListenerMap.TryGetValue(kv, out wrap))
            {
                wrap = new ListenerWrap();
                m_AllListenerMap.Add(kv, wrap);
            }

            if (wrap.Add(fun))
            {
                return true;
            }

            Debug.LogWarning("Already Register Same Event:" + key);
            return false;
        }

        public static void UnRegister<T>(T key, OnEvent fun) where T : IConvertible
        {
            ListenerWrap wrap;
            if (m_AllListenerMap.TryGetValue(key.ToInt32(null), out wrap))
            {
                wrap.Remove(fun);
            }
        }

        public static bool Send<T>(T key, params object[] param) where T : IConvertible
        {
            int kv = key.ToInt32(null);
            ListenerWrap wrap;
            if (m_AllListenerMap.TryGetValue(kv, out wrap))
            {
                return wrap.Fire(kv, param);
            }
            return false;
        }

        #region 内部结构
        private class ListenerWrap
        {
            private LinkedList<OnEvent> m_EventList;
            public bool Fire(int key, params object[] param)
            {
                if (m_EventList == null)
                {
                    return false;
                }

                LinkedListNode<OnEvent> next = m_EventList.First;
                OnEvent call = null;
                LinkedListNode<OnEvent> nextCache = null;

                while (next != null)
                {
                    call = next.Value;
                    nextCache = next.Next;
                    call(key, param);

                    //1.该事件的回调删除了自己OK 2.该事件的回调添加了新回调OK， 3.该事件删除了其它回调(被删除的回调可能有回调，可能没有)
                    next = (next.Next == null) ? nextCache : next.Next;
                }

                return true;
            }

            public bool Add(OnEvent listener)
            {
                if (m_EventList == null)
                {
                    m_EventList = new LinkedList<OnEvent>();
                }

                if (m_EventList.Contains(listener))
                {
                    return false;
                }

                m_EventList.AddLast(listener);
                return true;
            }

            public void Remove(OnEvent listener)
            {
                if (m_EventList == null)
                {
                    return;
                }

                m_EventList.Remove(listener);
            }
        }
        #endregion
    }
}
