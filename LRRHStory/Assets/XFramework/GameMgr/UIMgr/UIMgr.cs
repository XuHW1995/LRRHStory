using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using DG;
using DG.Tweening;

namespace XFramework
{
    public class UIMgr : GameMgr<UIMgr>
    {
        #region 数据定义
        public UIRoot UIRoot;
        private Dictionary<UIID, UIPanelBase> m_ShowingPanel;
        private Dictionary<UIID, UIPanelBase> m_CachePanel;
        #endregion

        public override void Init()
        {
            m_ShowingPanel = new Dictionary<UIID, UIPanelBase>();
            m_CachePanel = new Dictionary<UIID, UIPanelBase>();

            UIDataTable.InitUIDataTable();
            UIRoot = Object.FindObjectOfType<UIRoot>();
            //Dotween初始化
            DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(100, 100);
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
                m_CachePanel.Remove(uiId);
                m_ShowingPanel.Add(uiId, thisPanel);
                thisPanel.Open(param);
            }
            else
            {
                AddUI(uiId, param);
            }
        }

        public void CloseUI(UIID uiId)
        {
            UIPanelBase thisPanel;
            if (m_ShowingPanel.TryGetValue(uiId, out thisPanel))
            {
                thisPanel.Close();
                m_ShowingPanel.Remove(uiId);
                m_CachePanel.Add(uiId, thisPanel);
            }
        }

        public UIView FindUI(UIID uiId)
        {
            UIPanelBase thisPanel;
            if (m_CachePanel.TryGetValue(uiId, out thisPanel))
            {
                return thisPanel.m_UIView;
            }

            return null;
        }

        private void AddUI(UIID uiId, params object[] param)
        {
            UIData uiStaticData = UIDataTable.GetUIData(uiId);
            ResMgr.S.LoadAsset(uiStaticData.ResPath, typeof(GameObject),
                (isSuccess, obj) =>
                {
                    if (!m_ShowingPanel.ContainsKey(uiId))
                    {
                        UIPanelBase newPanel = new UIPanelBase(uiStaticData, (GameObject)obj);
                        m_ShowingPanel.Add(uiId, newPanel);
                        newPanel.Open(param);
                    }
                }
            );
        }
    }
}

