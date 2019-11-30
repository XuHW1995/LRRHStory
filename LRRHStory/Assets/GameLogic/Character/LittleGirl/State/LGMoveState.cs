using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class LGMoveState : LGState
{
    //走跑表现切换时间
    private float m_Walk2RunTime = 0.8f;
    private float m_Walk2RunBlend = 0;

    public LGMoveState(AbstractFsm fsm) : base(fsm)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("进入移动状态");
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToMove.ToString(), true);
        DOTween.To(() => m_Walk2RunBlend, (m_Walk2RunBlend) => CurLGFsm.CurLGCtrl.LGAnimator.SetFloat(LGAnimatorConditionEnum.MoveBlend.ToString(), m_Walk2RunBlend), 1, m_Walk2RunTime);        
    }

    public override void OnDo()
    {
        base.OnDo();
        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.MoveState.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGMove);
        }

        DisposeMove();
        DisposeRotate();
    }

    public override void OnExit()
    {
        Debug.Log("退出移动状态");
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToMove.ToString(), false);
    }

    #region 运动控制
    //运动控制参数
    private float m_MoveSpeed = 5;
    private float m_RoateSpeed = 3;

    private void DisposeMove()
    {      
        float input_V = Input.GetAxisRaw("Vertical");       
        float curSpeed = m_MoveSpeed * input_V * Time.deltaTime;     
        CurLGFsm.CurLGCtrl.transform.Translate(CurLGFsm.CurLGCtrl.transform.forward * curSpeed, Space.World);

        //Debug.Log("MoveInfo: \n Input_V is : " + input_V + "\n CurrentSpeed is : " + curSpeed + "\n CurrentForward is : " + CurLGFsm.CurLGCtrl.transform.forward);
    }

    private void DisposeRotate()
    {
        float input_H = Input.GetAxis("Horizontal");
        CurLGFsm.CurLGCtrl.transform.Rotate(new Vector3(0, input_H * m_RoateSpeed, 0), Space.Self);
    }
    #endregion
}
