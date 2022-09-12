using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float Damage { get; private set; }
    public float AttackSpeed { get; private set; }
    public float AttackRelease { get; private set; }
    public float Range { get; private set; }
    public float ScopeAngle { get; private set; }

    private float RangeMultiplicator;

    public Weapon(float damage, float attackSpeed, float attackRelease, float range, float scopeAngle)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        AttackRelease = attackRelease;
        Range = range;
        ScopeAngle = scopeAngle;
    }

    public void Hit()
    {

    }
}
