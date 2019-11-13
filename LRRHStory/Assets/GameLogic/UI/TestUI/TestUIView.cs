using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;

public class TestUIView : UIView
{
    public Text ContentText;
    public Text GetParam;
    // Start is called before the first frame update
    public override void OpenUI(params object[] param)
    {
        //GetParam.text = param[0].ToString();
        TestUIModel.S.ContentText = param[0].ToString();
    }

    public void OnBtnClickTest()
    {
        ContentText.text = TestUIModel.S.ContentText;
    }
}
