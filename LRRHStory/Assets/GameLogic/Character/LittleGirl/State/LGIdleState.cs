using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGIdleState : StateBase
{
    private LGFsm m_Fsm;
    public LGIdleState(AbstractFsm fsm) : base(fsm)
    {
        m_Fsm = (LGFsm)fsm;
    }

    public override void OnEnter()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToIdel, true);
    }

    public override void OnDo()
    {
        if (m_Fsm.m_LGCtrl.LGAnimator.GetCurrentAnimatorStateInfo(0).IsName(LGAnimatorParms.LG_IdleStateName))
        {
            m_Fsm.m_LGCtrl.LGAnimator.SetInteger(LGAnimatorParms.LG_Int_CurState, (int)LGStateEnum.LGIdle);
        }
    }

    public override void OnExit()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToIdel, false);
    }
}
