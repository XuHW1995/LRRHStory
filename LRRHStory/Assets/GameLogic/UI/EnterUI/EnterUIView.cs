using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class EnterUIView : UIView
{
    public override void OpenUI(params object[] param)
   {
       base.OpenUI(param);
       DebugMgr.S.Log("打开游戏开始面板");
   }

    public void OnEnterBtnClick()
    {
        UIMgr.S.OpenUI(UIID.LoadingUI);
    }
}
