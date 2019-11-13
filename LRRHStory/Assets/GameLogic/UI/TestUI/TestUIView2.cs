using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;

public class TestUIView2 : UIView
{
    public Text ContentText;
    // Start is called before the first frame update
    public override void OpenUI(params object[] param)
    {
        ContentText.text = param[0].ToString();
    }

    public void OnBtnClickTest()
    {
        ContentText.text = TestUIModel.S.ContentText;
    }
}
