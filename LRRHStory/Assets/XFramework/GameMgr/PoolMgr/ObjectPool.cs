using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    sealed class ObjectPool<TObjofPool> : AbstractObjectPool, IPool<TObjofPool> where TObjofPool : AbstractObjectOfPool, new()
    {
        private string m_name = string.Empty;
        private readonly int m_MaxCacheCount = 10;
        private List<TObjofPool> m_CacheObjList;

        public ObjectPool(string name)
        {
            m_CacheObjList = new List<TObjofPool>();
            m_name = name;
        }

        public TObjofPool GetObj()
        {
            if (m_CacheObjList.Count > 0)
            {
                TObjofPool item = m_CacheObjList[0];
                m_CacheObjList.Remove(m_CacheObjList[0]);
                item.OnUse();
                DebugMgr.Log(string.Format("从对象池{0}的缓存中获取对象", m_name));
                return item;
            }

            DebugMgr.Log(string.Format("在对象池{0}中创建对象", m_name));
            return new TObjofPool();
        }

        public void RecycleObj(TObjofPool obj)
        {
            if (m_CacheObjList.Count <= m_MaxCacheCount)
            {
                m_CacheObjList.Add(obj);
                obj.Reset();
            }
        }

        public override void Release()
        {
            foreach (TObjofPool item in m_CacheObjList)
            {
                item.Release();
            }
            m_CacheObjList.Clear();
        }

        public override void ReleaseFreeObj()
        {
            for (int i = m_CacheObjList.Count - 1; i >= 0 ; i--)
            {
                if (m_CacheObjList[i].Free)
                {
                    m_CacheObjList[i].Release();
                    m_CacheObjList.Remove(m_CacheObjList[i]);
                }
            }
        }
    }
}
