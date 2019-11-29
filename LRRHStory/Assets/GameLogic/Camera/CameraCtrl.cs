using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform m_TargetAgent;
    private Vector3 m_OffsetDis;
    public void Start()
    {
        m_OffsetDis = this.transform.position - m_TargetAgent.position; 
    }

    public void LateUpdate()
    {
        this.transform.position = m_TargetAgent.transform.position + m_OffsetDis;
    }
}

