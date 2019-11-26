using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class LGMoveState : LGState
{
    //走跑表现切换时间
    private float m_Walk2RunTime = 0.5f;
    private float m_Walk2RunBlend = 0;

    public LGMoveState(AbstractFsm fsm) : base(fsm)
    {

    }

    public override void OnEnter()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToMove, true);
        DOTween.To(() => m_Walk2RunBlend, (m_Walk2RunBlend) => m_Fsm.m_LGCtrl.LGAnimator.SetFloat(LGAnimatorParms.LG_Float_MoveBlend, m_Walk2RunBlend), 1, m_Walk2RunTime);        
    }

    public override void OnDo()
    {
        if (m_Fsm.m_LGCtrl.LGAnimator.GetCurrentAnimatorStateInfo(0).IsName(LGAnimatorParms.LG_MoveStateName))
        {
            m_Fsm.m_LGCtrl.LGAnimator.SetInteger(LGAnimatorParms.LG_Int_CurState, (int)LGStateEnum.LGMove);
        }

        if (!Input.GetKey(KeyCode.W))
        {
            m_Fsm.ChangeState(StateEnum.Idle);
        }
    }

    public override void OnExit()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToMove, false);
    }


}
