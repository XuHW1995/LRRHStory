using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class ResMgr : GameMgr<ResMgr>
    {
        private IResLoader m_curResLoader = null;

        public override void Init()
        {
            Debug.Log("资源管理器初始化");
        }

        public override void Start()
        {
            Debug.Log("资源管理器进入游戏");
        }

        public override void Update()
        {
            //Debug.Log("资源管理器轮询");
        }

        public void LoadAsset()
        {

        }


    }
}


