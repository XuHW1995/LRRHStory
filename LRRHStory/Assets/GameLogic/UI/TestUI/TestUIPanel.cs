using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIPanel : MonoBehaviour
{
    public Text ContentText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClickTest()
    {
        ContentText.text = TestUIModel.S.ContentText;
    }
}
