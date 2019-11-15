using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public enum UIID
    {
        TestUI,
        TestUI2,
        EnterUI,
        LoadingUI,
        MainUI,
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
            AddTable(UIID.TestUI, "Assets/GameRes/Prefabs/UI/TestUIPanel.prefab", typeof(TestUIView));
            AddTable(UIID.TestUI2, "Assets/GameRes/Prefabs/UI/TestUIPanel2.prefab", typeof(TestUIView2));

            AddTable(UIID.EnterUI, "Assets/GameRes/Prefabs/UI/EnterUI/EnterUI.prefab", typeof(EnterUIView));
            AddTable(UIID.LoadingUI, "Assets/GameRes/Prefabs/UI/EnterUI/LoadingUI.prefab", typeof(LoadingUIView));

            AddTable(UIID.MainUI, "Assets/GameRes/Prefabs/UI/MainUI/MainUI.prefab", typeof(MainUIView));
        }

        public static UIData GetUIData(UIID uiId)
        {
            UIData thisUIData;
            if (UIDataTableDic.TryGetValue(uiId, out thisUIData))
            {
                return thisUIData;
            }

            DebugMgr.S.LogError(uiId.ToString() + "Don't init!");
            return null;
        }

        private static void AddTable(UIID uiId, string resPath, Type panelType)
        {
            UIDataTableDic.Add(uiId, new UIData(uiId, resPath, panelType));
        }
    }
}
