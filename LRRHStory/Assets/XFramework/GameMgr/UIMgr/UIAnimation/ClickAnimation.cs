using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ClickAnimation : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public bool IsOn = true;
    public float m_ScaleFactor = 0.85f;
    public float m_AnimationTime = 0.15f;

    private Vector3 m_SourceScale;   
    private Vector3 m_EndScale;
    private bool isDown = false;

    public void Awake()
    {
        m_SourceScale = transform.localScale;
        m_EndScale = m_SourceScale * m_ScaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Down();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up();
    }

    public void Down()
    {
        isDown = true;

        if (IsOn)
        {
            transform.localScale = m_SourceScale;
            transform.DOScale(m_EndScale, m_AnimationTime).OnComplete(() => {
                if (!isDown)
                {
                    transform.localScale = m_SourceScale;
                }
            });
        }
    }

    public void Up()
    {
        isDown = false;

        if (IsOn)
        {
            transform.localScale = m_SourceScale;
        }
    }
}

