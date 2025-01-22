using UnityEngine;

public class NewBehaviourScript : ScriptableObject
{
    public float Cooldown = 10f;
    public int Damage = 5;
    public int UnlockLevel = 1;

    public bool IsActivating;

    protected float UseTime;


    public virtual SkillScriptableObject ScaleUpForLevel(ScalingScriptableObject Scaling, int Level)
    {
        SkillScriptableObject scaledSkill = CreateInstance<SkillScriptableObject>();

        scaleUpBaseValuesForLevel(scaledSkill, Scaling, Level);

        return scaledSkill;
    }

    protected virtual void scaleUpBaseValuesForLevel(SkillScriptableObject Instance, ScalingScriptableObject Scaling, int Level)
    {
        Instance.name = name;

        Instance.Cooldown = Cooldown;
        Instance.Damage = Damage + Mathf.FloorToInt(Scaling,DamageCurve.Evaluate(Level));
        Instance.UnlockLevel = UnlockLevel;
    }

    public virtual void UseSkill(musketeer musketeer, enemy enemy)
    {
        IsActivating = true;
    }

    //check if skill can be used
    public virtual bool CanUseSkill(musketeer musketeer, enemy enemy, int Level)
    {
        return Level >= UnlockLevel;
    }
}
