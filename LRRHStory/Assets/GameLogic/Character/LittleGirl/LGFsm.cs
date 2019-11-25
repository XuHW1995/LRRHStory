using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGFsm : AbstractFsm
{
    public LGCtrl m_LGCtrl;
    public StateEnum m_CurrStateEnum { get; private set; }
    public StateEnum m_LastStateEnum { get; private set; }

    private StateBase m_Curstate = null;
    private Dictionary<StateEnum, StateBase> m_StateDic;

    public LGFsm(LGCtrl lgctrl, StateEnum curStateEnum)
    {
        m_LGCtrl = lgctrl;
        m_StateDic = new Dictionary<StateEnum, StateBase>();
        m_StateDic[StateEnum.Idle] = new LGIdleState(this);
        m_StateDic[StateEnum.Move] = new LGMoveState(this);
        //m_StateDic[StateEnum.Attack] = new RunState(this);
        //m_StateDic[StateEnum.Injured] = new DieState(this);
        //m_StateDic[StateEnum.Jump] = new JumpState(this);

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
}
