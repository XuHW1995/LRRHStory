using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class XFrameworkLauncher : SingleTon<XFrameworkLauncher>
    {
        private List<IGameMgr> m_mgrList = new List<IGameMgr>();
        public void BeginFramework()
        {
            m_mgrList.Add(ResMgr.instance);

            
            initMgr();
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

        }
    }
}
