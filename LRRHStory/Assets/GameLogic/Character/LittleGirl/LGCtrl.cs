using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class LGCtrl : MonoBehaviour
{
    #region 数据定义
    private LGFsm m_Fsm;
    public LGFsm MyFsm
    {
        get
        {
            return m_Fsm;
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
        m_Fsm = new LGFsm(this, StateEnum.Idle);
        m_Animator = GetComponent<Animator>();
        AddListener();
    }

    void Start()
    {

    }

    void Update()
    {
        m_Fsm.OnUpdate();
    }

    void Destroy()
    {
        RemoveListener();
    }

    #region  监听事件
    void AddListener()
    {
        EventSystem.RegisterEvent(EventId.KEY_W_DOWN, HanderWDown);
        EventSystem.RegisterEvent(EventId.KEY_W_UP, HanderWUp);
        EventSystem.RegisterEvent(EventId.KEY_SPACE_DOWN, HanderSpaceDown);
        EventSystem.RegisterEvent(EventId.KEY_X_UP, HanderXUp);
    }

    void RemoveListener()
    {
        EventSystem.UnregisterEvent(EventId.KEY_W_DOWN, HanderWDown);
        EventSystem.UnregisterEvent(EventId.KEY_W_UP, HanderWUp);
        EventSystem.UnregisterEvent(EventId.KEY_SPACE_DOWN, HanderSpaceDown);
        EventSystem.UnregisterEvent(EventId.KEY_X_UP, HanderXUp);
    }

    void HanderWDown(EventId eventenum, params object[] param)
    {
        m_Fsm.ChangeState(StateEnum.Move);
    }
       
    void HanderWUp(EventId eventenum, params object[] param)
    {
        if (m_Fsm.GetCurStateEnum() == StateEnum.Move)
        {
            m_Fsm.ChangeState(StateEnum.Idle);
        }           
    }

    void HanderSpaceDown(EventId eventenum, params object[] param)
    {
        m_Fsm.ChangeState(StateEnum.Jump);
    }

    void HanderXUp(EventId eventenum, params object[] param)
    {
        m_Fsm.ChangeState(StateEnum.Attack);
    }

    #endregion

    #region 动画事件
    //起跳
    void LGJumpLeaveFloor()
    {
        LGJumpState jumpState = (LGJumpState)m_Fsm.GetCurState();
        jumpState.SetInSky(true);
    }

    //落地
    void LGJumpFallFloor()
    {
        LGJumpState jumpState = (LGJumpState)m_Fsm.GetCurState();
        jumpState.SetInSky(false);
    }

    //跳动画结束
    void LGJumpEnd()
    {
        //Debug.Log("跳动画结束");
        //m_Fsm.GoBackLastState();        
    }
    #endregion
}
