using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace XFramework
{
    public class UIMgr : GameMgr<UIMgr>
    {
        #region 数据定义
        public Transform UIRoot;

        private static int instanceId = 0;
        private Dictionary<UIID, UIPanelBase> m_ShowingPanel;
        private Dictionary<UIID, UIPanelBase> m_CachePanel;
        #endregion

        public override void Init()
        {
            m_ShowingPanel = new Dictionary<UIID, UIPanelBase>();
            m_CachePanel = new Dictionary<UIID, UIPanelBase>();

            UIDataTable.InitUIDataTable();
            UIRoot = GameObject.Find("GameLauncher/UIMgr/UIRoot").transform;
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
            UIPanelBase thisPanel;
            if (m_CachePanel.TryGetValue(uiId, out thisPanel))
            {
                thisPanel.Open(UIRoot, param);
            }
            else
            {
                AddUI(uiId, param);
            }
        }

        public void CloseUI(UIID uiId)
        {

        }

        public void FindUI(UIID uiId)
        {

        }

        private void AddUI(UIID uiId, params object[] param)
        {
            UIData uiStaticData = UIDataTable.GetUIData(uiId);
            ResMgr.instance.LoadAsset(uiStaticData.ResPath, typeof(GameObject), 
                (isSuccess, obj)=> 
                {
                    UIPanelBase newPanel = new UIPanelBase(UIRoot, uiId, (GameObject)obj, ++instanceId);                   
                    m_ShowingPanel.Add(uiId, newPanel);
                    newPanel.Open(param);
                }
            );           
        }

        private void RemoveUI(UIID uiId)
        {

        }
    }
}

