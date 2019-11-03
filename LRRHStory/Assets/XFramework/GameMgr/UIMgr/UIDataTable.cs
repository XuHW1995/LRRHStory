using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public enum UIID
    {
        TestUIPanel,
    }

    public class UIData
    {
        public UIID UIId { get; }
        public string ResPath { get; }
        public Type UIType { get; }

        public UIData(UIID uiId, string resPath, Type panelType)
        {
            UIId = uiId;
            ResPath = resPath;
            UIType = panelType;
        }
    }

    public static class UIDataTable
    {
        public static Dictionary<UIID, UIData> UIDataTableDic = new Dictionary<UIID, UIData>();

        public static void InitUIDataTable()
        {
            AddTable(UIID.TestUIPanel, "Assets/GameRes/Prefabs/UI/TestUIPanel.prefab", typeof(TestUIPanel));
        }

        public static UIData GetUIData(UIID uiId)
        {
            UIData thisUIData;
            if (UIDataTableDic.TryGetValue(uiId, out thisUIData))
            {
                return thisUIData;
            }

            DebugMgr.instance.LogError(uiId.ToString() + "Don't init!");
            return null;
        }

        private static void AddTable(UIID uiId, string resPath, Type panelType)
        {
            UIDataTableDic.Add(uiId, new UIData(uiId, resPath, panelType));
        }
    }
}
