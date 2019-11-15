using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class GameLauncher : MonoBehaviour
{
    void Awake()
    {
        XFrameworkLauncher.S.BeginFramework();
    }

    void Start()
    {
        XFrameworkLauncher.S.Start();
        //功能测试
        Test.ModuleTest();

        UIMgr.S.OpenUI(UIID.EnterUI);
    }

    void Update()
    {
        XFrameworkLauncher.S.Update();
    }
}
