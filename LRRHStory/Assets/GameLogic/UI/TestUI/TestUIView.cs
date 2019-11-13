﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;

public class TestUIView : UIView
{
    public Text ContentText;
    // Start is called before the first frame update
    public override void OpenUI(params object[] param)
    {
        TestUIModel.S.ContentText = param[0].ToString();
    }

    public void OnBtnClickTest()
    {
        ContentText.text = TestUIModel.S.ContentText;

        UIMgr.S.OpenUI(UIID.TestUI2, "打开第二个面板了");
    }
}
