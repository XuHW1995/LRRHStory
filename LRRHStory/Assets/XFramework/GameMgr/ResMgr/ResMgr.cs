using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XFramework
{
    public delegate void LoadAssetCallBack(bool success, UnityEngine.Object asset);

    public class ResMgr : GameMgr<ResMgr>
    {
        private IResLoader m_curResLoader = null;
        public override void Init()
        {
            if (ConfigMgr.instance.GlobalConfig.EditorModel)
            {
                m_curResLoader = new EditorResLoader();         
            }
            else
            {
                //m_curResLoader = new RelaseResLoader();
            }

            DebugMgr.instance.Log("资源管理器初始化完成");
        }

        public override void Start()
        {
            DebugMgr.instance.Log("资源管理器进入游戏");
        }

        public override void Update()
        {
            m_curResLoader.Update();
        }

        public void LoadAsset(string name, Type assetType, LoadAssetCallBack cb)
        {
            m_curResLoader.LoadAsset(name, assetType, cb);
        }

        public void LoadScene(string sceneName)
        {

        }
    }
}


