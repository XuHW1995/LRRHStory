using UnityEngine;

public enum LGStateEnum
{
    LGIdle = 0,
    LGMove = 1,
    LGJump = 2,
    LGAttack1 = 3,
    LGAttack2 = 4,
    LGAttack3 = 5,
}

/// <summary>
/// 小红帽动画层级
/// </summary>
public enum LGAnimatorLayer
{
    BaseLayer = 0,
}

/// <summary>
/// 小红帽动画状态名
/// </summary>
public enum LGAnimatorStateNameEnum
{
    IdleState,
    MoveState,
    JumpState,
    AttackState1,
    AttackState2,
    AttackState3,
}

/// <summary>
/// 小红帽动画状态机参数
/// </summary>
public enum LGAnimatorConditionEnum
{
    CurState,
    ToMove,
    ToIdle,
    ToJump,
    MoveBlend,
    ToAttack, //普通攻击1
    ComboIndex,
}

public abstract class LGState : StateBase
{
    public LGFsm CurLGFsm;
    public AnimatorStateInfo CurAnimatorStateInfo;

    public LGState(AbstractFsm fsm)
    {
        CurLGFsm = (LGFsm)fsm;
    }

    public override void OnEnter()
    {
    }

    public override void OnDo()
    {
        CurAnimatorStateInfo = CurLGFsm.CurLGCtrl.LGAnimator.GetCurrentAnimatorStateInfo(0);
        //TODO 此处回待机状态的逻辑写的感觉不太好，但是没有想到一个好的解决方式
        if (!Input.GetKey(KeyCode.W) 
            && CurLGFsm.GetCurStateEnum() != StateEnum.Jump
            && CurLGFsm.GetCurStateEnum() != StateEnum.Attack)
        {
            CurLGFsm.ChangeState(StateEnum.Idle);
        }
    }

    public override void OnExit()
    {
      
    }
}

