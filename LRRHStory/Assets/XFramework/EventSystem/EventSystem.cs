using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    /// <summary>
    /// 事件回调委托
    /// </summary>
    /// <param name="eventenum"></param>
    /// <param name="param"></param>
    public delegate void EventHandler(EventId eventenum, params object[] param);

    public static class EventSystem
    {
        private const int maxEventHandlersCount = 50;
        private static Dictionary<EventId, EventHandlerCollection> m_AllListenerMap = new Dictionary<EventId, EventHandlerCollection>(maxEventHandlersCount);

        /// <summary>
        /// 注册监听
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="eventHander"></param>
        public static void RegisterEvent(EventId eventId, EventHandler handler)
        {
            EventHandlerCollection handlers;
            if (!m_AllListenerMap.TryGetValue(eventId, out handlers))
            {
                handlers = new EventHandlerCollection();
                handlers.Add(handler);
                m_AllListenerMap.Add(eventId, handlers);
                return;
            }

            handlers.Add(handler);
        }

        /// <summary>
        /// 注销监听
        /// </summary>
        /// <param name="eventId"></param>
        public static void UnregisterEvent(EventId eventId, EventHandler handler)
        {
            EventHandlerCollection handlers;          
            if (m_AllListenerMap.TryGetValue(eventId, out handlers))
            {
                handlers.Remove(handler);
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        public static void SendEvent(EventId eventId, params object[] param)
        {
            EventHandlerCollection handlers;
            if (m_AllListenerMap.TryGetValue(eventId, out handlers))
            {
                handlers.Fire(eventId, param);
            }
        }

        #region 事件回调集合类
        private class EventHandlerCollection
        {
            LinkedList<EventHandler> m_handlerList;
            
            /// <summary>
            /// 新增回调
            /// </summary>
            /// <param name="handler"></param>
            public void Add(EventHandler handler)
            {
                if (m_handlerList == null)
                {
                    m_handlerList = new LinkedList<EventHandler>();
                }

                if (m_handlerList.Contains(handler))
                {
                    return;
                }

                m_handlerList.AddLast(handler);
            }

            /// <summary>
            /// 移除回调
            /// </summary>
            /// <param name="handler"></param>
            public void Remove(EventHandler handler)
            {
                if (m_handlerList == null)
                {
                    return;
                }

                m_handlerList.Remove(handler);
            }

            /// <summary>
            /// 触发回调
            /// </summary>
            /// <param name="eventId"></param>
            /// <param name="param"></param>
            public void Fire(EventId eventId, params object[] param)
            {
                if (m_handlerList == null)
                {
                    return;
                }

                LinkedListNode<EventHandler> thisHandler = m_handlerList.First;
                EventHandler callback = null;
                LinkedListNode<EventHandler> nextCache = null;

                while (thisHandler != null)
                {
                    callback = thisHandler.Value;
                    nextCache = thisHandler.Next;
                    callback(eventId, param);

                    ////1.该事件的回调删除了自己OK 2.该事件的回调添加了新回调OK， 3.该事件删除了其它回调(被删除的回调可能有回调，可能没有)
                    //next = next.Next == null ? nextCache : next.Next;

                    if (thisHandler.Next == null)
                    {
                        break;
                    }
                    else
                    {
                        thisHandler = thisHandler.Next;
                    }
                }
            }
        }
        #endregion
    }
}

