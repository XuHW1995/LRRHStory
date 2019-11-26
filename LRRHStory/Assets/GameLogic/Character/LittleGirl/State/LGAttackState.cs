using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGAttackState : LGState
{
    private int m_ComboIndex;
    //上一次攻击时刻
    private float m_LastAttackTime = 0;
    //最大攻击间隔
    private float m_MaxAttackInterval = 0.8f;
    //攻击CD定时器
    private float m_AttackCdTimer = 0;
    //攻击CD标志
    private bool m_AttackCding = false;
    //攻击CD
    private float m_AttackCd = 0.3f;

    public LGAttackState(AbstractFsm FSM): base(FSM) { }

    public override void OnEnter()
    {
        Init();
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToAttack.ToString(), true);
    }

    private void Init()
    {
        m_ComboIndex = 0;
        m_LastAttackTime = Time.time;
        CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.ComboIndex.ToString(), m_ComboIndex);
    }

    public override void OnDo()
    {
        base.OnDo();

        if (!m_AttackCding)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                m_AttackCding = true;
                m_LastAttackTime = Time.time;
                m_ComboIndex++;

                if (m_ComboIndex > 2)
                {
                    m_ComboIndex = 0;
                }

                CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.ComboIndex.ToString(), m_ComboIndex);
            }
        }
        else
        {
            m_AttackCdTimer = m_AttackCdTimer + Time.deltaTime;
            if (m_AttackCdTimer >= m_AttackCd)
            {
                m_AttackCdTimer = 0;
                m_AttackCding = false;
            }
        }

        //俩次攻击间隔超过m_MaxAttackInterval，则回到待机状态
        if (Time.time - m_LastAttackTime >= m_MaxAttackInterval)
        {
            CurLGFsm.ChangeState(StateEnum.Idle);
        }

        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.AttackState1.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGAttack1);
        }

        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.AttackState2.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGAttack2);
        }

        if (CurAnimatorStateInfo.IsName(LGAnimatorStateNameEnum.AttackState3.ToString()))
        {
            CurLGFsm.CurLGCtrl.LGAnimator.SetInteger(LGAnimatorConditionEnum.CurState.ToString(), (int)LGStateEnum.LGAttack3);
        }
    }

    public override void OnExit()
    {
        CurLGFsm.CurLGCtrl.LGAnimator.SetBool(LGAnimatorConditionEnum.ToAttack.ToString(), false);
    }
}
