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

    private float RangeMultiplicator = 2;

    public Weapon(float damage, float attackSpeed, float attackRelease, float range, float scopeAngle)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        AttackRelease = attackRelease;
        Range = range;
        ScopeAngle = Mathf.Clamp(scopeAngle, 0, 360);
    }

    public void Hit()
    {
        GameObject Enemy = EnemyInRange();

        if (Enemy == null) return;

        Enemy.GetComponent<Enemy>().TakeDamage(Damage);
    }

    private GameObject EnemyInRange()
    {
        //in Range?

        Vector2 position = Player.Instance.transform.position;
        float radius = Range * RangeMultiplicator;
        int layer = Enemy.layerMask;

        Collider2D enemyCollider = Physics2D.OverlapCircle(position, radius, layer);

        if (enemyCollider == null) return null;

        //in Scope?

        GameObject enemy = enemyCollider.gameObject;

        Vector2 mousePos = MouseToWorldPos(Input.mousePosition);
        Vector2 enemyPos = enemy.transform.position;
        Vector2 playerPos = Player.Instance.transform.position;

        if (!EnemyInScopeAngle(mousePos, enemyPos, playerPos)) return null;

        return enemy;
    }

    private bool EnemyInScopeAngle(Vector2 mousePos, Vector2 enemyPos, Vector2 playerPos)
    {
        float angleMouse = CalcAngle(playerPos, mousePos);
        float angleEnemy = CalcAngle(playerPos, enemyPos);

        float angleMin = angleMouse - ScopeAngle / 2;
        float angleMax = angleMouse + ScopeAngle / 2;

        if(angleMin <= 0)
        {
            if (angleEnemy <= angleMax) return true;
            if (angleEnemy >= angleMin + 360) return true;
            return false;
        }

        if(angleMax >= 360)
        {
            if (angleEnemy >= angleMin) return true;
            if (angleEnemy <= angleMax - 360) return true;
            return false;
        }

        if (angleEnemy < angleMin) return false;
        if (angleEnemy > angleMax) return false;
        return true;

    }

    private float CalcAngle(Vector2 pos1, Vector2 pos2)
    {
        float dx = pos2.x - pos1.x;
        float dy = pos2.y - pos1.y;

        if (dx == 0 && dy > 0) return 90f;
        if (dx == 0) return 270f;

        float angle = Mathf.Rad2Deg * Mathf.Atan(dy / dx);

        if (dx < 0) return angle + 180;
        if (dy < 0) return angle + 360;
        return angle;

    }

    private Vector2 MouseToWorldPos(Vector3 screenPosition)
    {
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}
