using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class LGCtrl : MonoBehaviour
{
    #region 数据定义
    private LGFsm m_fsm;
    public LGFsm MyFsm
    {
        get
        {
            return m_fsm;
        }
    }

    private Animator m_Animator;
    [HideInInspector]
    public Animator LGAnimator
    {
        get { return m_Animator; }
    }
    #endregion

    void Awake()
    {
        m_fsm = new LGFsm(this, StateEnum.Idle);
        m_Animator = GetComponent<Animator>();
        AddListener();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_fsm.OnUpdate();
    }

    void Destroy()
    {
        Debug.Log("移除事件监听");
        RemoveListener();
    }

    #region  监听事件
    void AddListener()
    {
        EventSystem.RegisterEvent(EventId.KEY_W_DOWN, HanderWDown);
        EventSystem.RegisterEvent(EventId.KEY_W_UP, HanderWUp);
    }

    void RemoveListener()
    {
        EventSystem.UnregisterEvent(EventId.KEY_W_DOWN, HanderWDown);
        EventSystem.UnregisterEvent(EventId.KEY_W_UP, HanderWUp);
    }

    void HanderWDown(EventId eventenum, params object[] param)
    {
        //m_fsm.ChangeState(StateEnum.Move);
    }

    void HanderWUp(EventId eventenum, params object[] param)
    {
        //m_fsm.ChangeState(StateEnum.Idle);
        m_fsm.ChangeState(StateEnum.Move);
    }
    #endregion

    public void ResetParams()
    {
        LGAnimator.SetInteger("CurState", 0);
        LGAnimator.SetBool("ToMove", false);
        LGAnimator.SetBool("ToMove", false);
    }
}
