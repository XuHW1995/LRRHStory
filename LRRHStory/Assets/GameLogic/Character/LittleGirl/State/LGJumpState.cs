using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGJumpState : LGState
{
    public LGJumpState(AbstractFsm fsm) : base(fsm)
    {

    }

    public override void OnEnter()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToJump, true);
    }

    public override void OnDo()
    {
        if (m_Fsm.m_LGCtrl.LGAnimator.GetCurrentAnimatorStateInfo(0).IsName(LGAnimatorParms.LG_JumpStateName))
        {
            m_Fsm.m_LGCtrl.LGAnimator.SetInteger(LGAnimatorParms.LG_Int_CurState, (int)LGStateEnum.LGJump);
        }
    }

    public override void OnExit()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToJump, false);
    }
}