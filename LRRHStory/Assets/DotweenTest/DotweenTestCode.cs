using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DotweenTestCode : MonoBehaviour
{
    public Transform Cube;
    public RectTransform Mpanel;

    private Tweener m_Tweener;
    private bool m_isIn = false;

    void Start()
    {
        //NormalTest();
        //TweenerTest();
        //FromTest();
        aniAtrrSet();
    }
    #region Dotween fun test
    //对值进行查值
    void NormalTest()
    {
        DOTween.To(() => Cube.localPosition, x => Cube.localPosition = x, new Vector3(10,10,10), 5);
    }
    //一般动画方法
    void TweenerTest()
    {
        m_Tweener = Mpanel.DOLocalMove(Vector3.zero, 1, true);
        m_Tweener.SetAutoKill(false);
        m_Tweener.Pause();
    }
    //from方法
    void FromTest()
    {
        //X移動5
        Cube.transform.DOMoveX(5, 1);
        //X从5移动到当前
        Cube.transform.DOMoveX(5, 1).From();
        //X从当前位置的相对5的位置移动回来
        Cube.transform.DOMoveX(5, 1).From(true);
    }
    //
    void aniAtrrSet()
    {
        Tweener thisTW = Mpanel.DOLocalMoveX(0, 2);
        thisTW.SetEase(Ease.InOutBack);
        thisTW.SetLoops(2);
        thisTW.OnComplete(()=>{ Debug.Log("动画播放完成"); });
    }

    #endregion
    public void OnTestClick()
    {
        if (!m_isIn)
        {
            m_isIn = true;
            m_Tweener.PlayForward();
        }
        else
        {
            m_isIn = false;
            m_Tweener.PlayBackwards();
        }
    }
}
