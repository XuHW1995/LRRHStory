using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGJumpState : LGState
{
    public LGJumpState(AbstractFsm fsm) : base(fsm) { }

    public override void OnEnter()
    {
        Debug.Log("进入跳状态");
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToJump.ToString(), true);
    }

    public override void OnDo()
    {
        base.OnDo();
        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.JumpState.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGJump);

            Debug.Log("CurAnimatorStateInfo.normalizedTime" + CurAnimatorStateInfo.normalizedTime);
            if (CurAnimatorStateInfo.normalizedTime > 1)
            {
                CurLGFsm.GoBackLastState();
            }
        }
    }

    public override void OnExit()
    {
        Debug.Log("退出跳状态");
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToJump.ToString(), false);
    }
}