using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class UIMgr : GameMgr<UIMgr>
    {
        public override void Init()
        {
            base.Init();
            BaseEventSystem.Register(1, (a, b) => { Debug.Log("UIMgr 接受消息执行响应函数" + a + b[0].ToString()); });
        }

        public override void Start()
        {
            base.Start();
        }

        public override void EnterGame()
        {
            base.EnterGame();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public void OpenUI()
        {

        }

        public void CloseUI()
        {

        }

        public void HideUI()
        {

        }

        public void FindUI()
        {

        }
    }
}

