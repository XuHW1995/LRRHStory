using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGMoveState : StateBase
{
    private LGFsm m_Fsm;
    public LGMoveState(AbstractFsm fsm) : base(fsm)
    {
        m_Fsm = (LGFsm)fsm;
    }

    public override void OnEnter()
    {
        m_Fsm.m_LGCtrl.ResetParams();
        m_Fsm.m_LGCtrl.LGAnimator.SetBool("ToMove", true);
       // m_Fsm.m_LGCtrl.LGAnimator.SetInteger("CurState", 1);
        Debug.Log("LGMoveState enter");
    }

    public override void OnDo()
    {
       // m_Fsm.m_LGCtrl.LGAnimator.SetInteger("CurState", 1);
    }

    public override void OnExit()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool("ToMove", false);
        Debug.Log("LGMoveState exit");
    }
}
