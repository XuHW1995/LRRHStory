using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class GameLauncher : MonoBehaviour
{
    void Awake()
    {
        XFrameworkLauncher.instance.BeginFramework();
    }

    void Start()
    {
        XFrameworkLauncher.instance.Start();
        //功能测试
        Test.ModuleTest();
        UIMgr.instance.OpenUI(UIID.TestUIPanel, "打开测试面板传入参数");
    }

    void Update()
    {
        XFrameworkLauncher.instance.Update();
    }
}
