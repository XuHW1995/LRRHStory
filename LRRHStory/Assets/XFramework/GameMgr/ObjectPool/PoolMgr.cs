using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class PoolMgr : GameMgr<PoolMgr>
    {
        private Dictionary<string, AbstractObjectPool> m_poolDic;
        #region 生命周期
        public override void Init()
        {
            m_poolDic = new Dictionary<string, AbstractObjectPool>();
        }

        public override void Destroy()
        {
            ReleaseAll();
        }
        #endregion

        //获取对象池
        public IPool<TObjofPool>GetPool<TObjofPool>(string name) where TObjofPool : AbstractObjectOfPool, new()
        {
            AbstractObjectPool pool = null;
            if (m_poolDic.TryGetValue(name, out pool))
            {
                return pool as ObjectPool<TObjofPool>;
            }

            pool = CreatNewPool<TObjofPool>(name);
            return pool as ObjectPool<TObjofPool>;
        }

        //创建对象池
        private AbstractObjectPool CreatNewPool<TObjofPool>(string name) where TObjofPool : AbstractObjectOfPool, new()
        {
            AbstractObjectPool newPool = new ObjectPool<TObjofPool>(name);
            m_poolDic.Add(name, newPool);
            return newPool;
        }

        //释放某个对象池
        public void ReleasePool(string name)
        {
            if (!m_poolDic.ContainsKey(name))
            {
                return;
            }

            m_poolDic[name].Release();
            m_poolDic.Remove(name);
        }

        //释放全部对象池
        public void ReleaseAll()
        {
            foreach(KeyValuePair<string, AbstractObjectPool> onepool in m_poolDic)
            {
                onepool.Value.Release();
            }
            m_poolDic.Clear();
        }
    }
}

