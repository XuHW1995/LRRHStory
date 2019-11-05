using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;

public class TestUIPanel : UIPanelBase
{
    public Text ContentText;
    public Text GetParam;
    // Start is called before the first frame update
    public override void OpenUI(params object[] param)
    {
        GetParam.text = (string)param[0];
    }

    public void OnBtnClickTest()
    {
        ContentText.text = TestUIModel.S.ContentText;
    }
}
