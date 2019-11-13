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
            m_mgrList.Add(ConfigMgr.S);
            m_mgrList.Add(ResMgr.S);    
            m_mgrList.Add(DebugMgr.S);
            m_mgrList.Add(PoolMgr.S);
            m_mgrList.Add(UIMgr.S);
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
