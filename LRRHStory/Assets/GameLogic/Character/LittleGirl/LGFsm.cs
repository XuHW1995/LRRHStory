using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGFsm : AbstractFsm
{
    public LGCtrl CurLGCtrl;
    public StateEnum CurrStateEnum { get; private set; }
    public StateEnum LastStateEnum { get; private set; }

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

        if (m_StateDic.ContainsKey(CurrStateEnum))
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
        if (CurrStateEnum == newStateEnum)
        {
            return;
        }

        if (m_Curstate != null)
        {
            m_Curstate.OnExit();
        }

        LastStateEnum = CurrStateEnum;
        CurrStateEnum = newStateEnum;
        m_Curstate = m_StateDic[newStateEnum];
        m_Curstate.OnEnter();
    }

    public override void GoBackLastState()
    {
        ChangeState(LastStateEnum);
    }

    public override T GetState<T>(StateEnum stateEnum)
    {
        return m_StateDic[stateEnum] as T;
    }

    public StateEnum GetCurState()
    {
        return CurrStateEnum;
    }
}
