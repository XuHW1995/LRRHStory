using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGFsm : AbstractFsm
{
    public LGCtrl CurLGCtrl;
    public StateEnum m_CurrStateEnum { get; private set; }
    public StateEnum m_LastStateEnum { get; private set; }

    private LGState m_Curstate = null;
    private Dictionary<StateEnum, LGState> m_StateDic;

    public LGFsm(LGCtrl lgCtrl, StateEnum curStateEnum)
    {
        CurLGCtrl = lgCtrl;
        m_StateDic = new Dictionary<StateEnum, LGState>();
        m_StateDic[StateEnum.Idle] = new LGIdleState(this);
        m_StateDic[StateEnum.Move] = new LGMoveState(this);
        m_StateDic[StateEnum.Jump] = new LGJumpState(this);
        m_StateDic[StateEnum.Attack] = new LGAttackState(this);

        if (m_StateDic.ContainsKey(m_CurrStateEnum))
        {
            m_Curstate = m_StateDic[curStateEnum];
        }
    }

    public override void OnUpdate()
    {
        m_Curstate.OnDo();
    }

    public override void ChangeState(StateEnum newStateEnum)
    {
        if (m_CurrStateEnum == newStateEnum)
        {
            return;
        }

        if (m_Curstate != null)
        {
            m_Curstate.OnExit();
        }

        m_LastStateEnum = m_CurrStateEnum;
        m_CurrStateEnum = newStateEnum;
        m_Curstate = m_StateDic[newStateEnum];
        m_Curstate.OnEnter();
    }

    public override void GoBackLastState()
    {
        ChangeState(m_LastStateEnum);
    }

    public override T GetState<T>(StateEnum stateEnum)
    {
        return m_StateDic[stateEnum] as T;
    }

    public StateEnum GetCurStateEnum()
    {
        return m_CurrStateEnum;
    }

    public LGState GetCurState()
    {
        return m_StateDic[m_CurrStateEnum];
    }
}
