using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using XFramework;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingUIView : UIView
{
    public Slider ProcesSlider;

    public override void OpenUI(params object[] param)
    {
        base.OpenUI(param);
        ProcesSlider.maxValue = 100;
        UIMgr.S.CloseUI(UIID.EnterUI);
        StartCoroutine(StartLoadMainScene());
    }

    IEnumerator StartLoadMainScene()
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync("Game_Main");
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                ProcesSlider.value = displayProgress;
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            ProcesSlider.value = displayProgress;
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;

        UIMgr.S.CloseUI(UIID.LoadingUI);
        UIMgr.S.OpenUI(UIID.MainUI);
    }
}

