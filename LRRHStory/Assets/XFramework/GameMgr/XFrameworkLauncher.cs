using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class XFrameworkLauncher : SingleTon<XFrameworkLauncher>
    {
        private List<IGameMgr> m_mgrList = new List<IGameMgr>();
        public void BeginFramework()
        {
            registerAllMgr();
            initMgr();
        }

        private void registerAllMgr()
        {
            m_mgrList.Add(ConfigMgr.instance);
            m_mgrList.Add(ResMgr.instance);    
            m_mgrList.Add(DebugMgr.instance);
            m_mgrList.Add(PoolMgr.instance);
        }

        private void initMgr()
        {
            foreach (var mgr in m_mgrList)
            {
                mgr.Init();
            }
        }

        public void Start()
        {
            foreach (var mgr in m_mgrList)
            {
                mgr.Start();
            }
        }

        public void Update()
        {
            foreach (var mgr in m_mgrList)
            {
                mgr.Update();
            }
        }

        public void Destroy()
        {
            foreach (var mgr in m_mgrList)
            {
                mgr.Destroy();
            }
        }
    }
}
