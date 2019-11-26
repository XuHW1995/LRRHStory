using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGIdleState : LGState
{
    public LGIdleState(AbstractFsm fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToIdle.ToString(), true);
    }

    public override void OnDo()
    {
        base.OnDo();
        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.IdleState.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGIdle);
        }
    }

    public override void OnExit()
    {
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToIdle.ToString(), false);
    }
}
