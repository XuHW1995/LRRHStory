using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class UIMgr : GameMgr<UIMgr>
    {
        #region 数据定义
        private Dictionary<UIID, UIPanel> m_ShowingPanel;
        private Dictionary<UIID, UIPanel> m_CachePanel;
        #endregion

        public override void Init()
        {
            m_ShowingPanel = new Dictionary<UIID, UIPanel>();
            m_CachePanel = new Dictionary<UIID, UIPanel>();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void EnterGame()
        {
            base.EnterGame();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public void OpenUI(UIID uiId, params object[] param)
        {
            //根据id加载或者找到prefab
            UIPanel thisPanel;
            if (m_CachePanel.TryGetValue(uiId, out thisPanel))
            {

            }
            //实例化prefab，并排序
        }

        public void CloseUI()
        {

        }

        public void HideUI()
        {

        }

        public void FindUI()
        {

        }
    }
}

