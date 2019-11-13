using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenTestCode : MonoBehaviour
{
    public Transform trans;

    public RectTransform Mpanel;

    private Tweener m_Tweener;

    private bool m_isIn = false;

    void Start()
    {
        //DOTween.To(() => trans.localPosition, x => trans.localPosition = x, new Vector3(10,10,10), 5);
        m_Tweener = Mpanel.DOLocalMove(Vector3.zero, 1, true);
        m_Tweener.SetAutoKill(false);
        m_Tweener.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
