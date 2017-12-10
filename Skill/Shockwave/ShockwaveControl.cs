using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveControl : MonoBehaviour {

    public LayerMask whatIsEnemy;

    float range = 3f;
    float damage;

    private void Start()
    {
        damage = SkillData.instance.skillData[1].firstDamage * Mathf.Pow(SkillData.instance.skillData[1].increaseDamageRatePerLevel, SkillData.instance.skillData[1].level - 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        foreach (Collider currentCollider in colliders)
        {
            EnemyHealth enemy = currentCollider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                if (enemy.isDead) return;
                enemy.StartDamage(damage, transform.position, 0.5f, 0.1f);
            }
        }
    }
}
