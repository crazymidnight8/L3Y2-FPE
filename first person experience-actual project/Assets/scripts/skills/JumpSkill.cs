using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkill : SkillScriptableObject
{
    public float MinJumpDistance = 1.5f;
    public float MaxJumpDistance = 5f;
    public AnimationCurve HeightCurve;
    public float JumpSpeed = 1;

    public override SkillScriptableObject ScaleUpForLevel(ScalingScriptableObject Scaling, int Level)
    {
        JumpSkill Instance = CreateInstance<JumpSkill>();

        scaleUpBaseValuesForLevel(Instance, Scaling, Level);
        Instance.MinJumpDistance = MinJumpDistance;
        Instance.MaxJumpDistance = MaxJumpDistance;
        Instance.HeightCurve = HeightCurve;
        Instance.JumpSpeed = JumpSpeed;

        return Instance;
    }

    public override bool CanUseSkill(musketeer musketeer, enemy enemy, int Level)
    {
        if (base.CanUseSkill(musketeer, enemy. Level))
        {
            float distance = Vector3.Distance(musketeer.transform.position, enemy.transform.position);

            return !IsActivating
                && UseTime + Cooldown < Time.time
                && distance >= MinJumpDistance
                && distance <= MaxJumpDistance;
        }

        return false;
    }

    public override void UseSkill(musketeer musketeer, enemy enemy)
    {
        base.UseSkill(musketeer, enemy);
        musketeer.StartCoroutine(Jump(musketeer, enemy));
    }

    private IEnumerator Jump(musketeer musketeer, enemy enemy)
    {
        musketeer.Agent.enabled = false;
        musketeer.Movement.enabled = false;
        musketeer.Movement.state = musketeerState.UsingAbility;

        Vector3 startingPosition = musketeer.transform.position;
        musketeer.Animator.SetTrigger(musketeer.Jump);

        for(float time = 0; time < 1; time += Time.deltaTime * JumpSpeed)
        {
            musketeer.transform.position = Vector3.Lerp(startingPosition, Player.transform.position, time)
                + Vector3.up * HeightCurve.Evaluate(time);
            musketeer.transform.rotation = Quaternion.Slerp(musketeer.transform.rotation,
                Quaternion.LookRotation(enemy,transform.position = musketeer.transform.position),
                time);

            yield return null;
        }
        musketeer.Animator.SetTrigger(musketeer.Landed);

        UseTime = Time.time;

        musketeer.enabled = true;
        musketeer.Movement.enabled = true;
        musketeer.Agent.enabled = true;

        
    }
}
