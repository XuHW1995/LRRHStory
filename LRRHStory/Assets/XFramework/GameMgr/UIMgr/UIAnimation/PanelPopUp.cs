using UnityEngine;
using DG.Tweening;

public class PanelPopUp : MonoBehaviour
{
    private bool m_IsFinish = false;
    private static Vector3 m_InitVector = new Vector3(0.001f, 0.001f, 0.001f);

    void Statr()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    void OnEnable()
    {
        m_IsFinish = false;
        Tweener t1 = gameObject.transform.DOScale(1.1f, 0.1f);
        Tweener t2 = gameObject.transform.DOScale(1f, 0.1f);
        DOTween.Sequence().Append(t1).Append(t2);

        t2.OnComplete<Tweener>(() =>
        {
            m_IsFinish = true;
        });
    }
}
