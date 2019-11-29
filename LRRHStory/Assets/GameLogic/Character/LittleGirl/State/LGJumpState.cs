using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGJumpState : LGState
{
    //运动控制参数
    private float m_JumpSpeed = 5;

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

            //Debug.Log("CurAnimatorStateInfo.normalizedTime" + CurAnimatorStateInfo.normalizedTime);
            if (CurAnimatorStateInfo.normalizedTime > 1)
            {
                CurLGFsm.GoBackLastState();
            }
        }

        DisposeMove();
    }

    public override void OnExit()
    {
        Debug.Log("退出跳状态");
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToJump.ToString(), false);
    }

    private void DisposeMove()
    {
        float input_V = Input.GetAxisRaw("Vertical");
        float curSpeed = m_JumpSpeed * input_V * Time.deltaTime;
        CurLGFsm.CurLGCtrl.transform.Translate(CurLGFsm.CurLGCtrl.transform.forward * curSpeed, Space.World);
    }

}