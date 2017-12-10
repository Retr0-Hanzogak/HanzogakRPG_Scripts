using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar_ShockwaveControl : MonoBehaviour
{

    public LayerMask whatIsEnemy;

    float range = 1.5f;
    float damage;

    private void Start()
    {
        damage = SkillData.instance.skillData[1].firstDamage * Mathf.Pow(SkillData.instance.skillData[1].increaseDamageRatePerLevel, SkillData.instance.skillData[1].level - 1) * 0.5f;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        foreach (Collider currentCollider in colliders)
        {
            EnemyHealth enemy = currentCollider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                if (enemy.isDead) return;
                enemy.OnDamage(damage);
            }
        }
    }
}
