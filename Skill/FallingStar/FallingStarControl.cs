using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarControl : MonoBehaviour {
    
    public ParticleSystem hitEff;

    Vector3 enemyPos;
    float speed = 30f;
    float damage;
    bool isHit = false;
    int skillNum = 1;

    private void Start()
    {
        damage = SkillData.instance.skillData[skillNum].firstDamage * Mathf.Pow(SkillData.instance.skillData[skillNum].increaseDamageRatePerLevel, SkillData.instance.skillData[skillNum].level - 1);
    }
    

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach(Collider currentCollider in colliders)
        {
            if (currentCollider.tag != "Player")
            {
                isHit = true;
                if (currentCollider.tag == "Enemy")
                {
                    enemyPos = currentCollider.transform.position;
                    EnemyHealth enemy = currentCollider.GetComponent<EnemyHealth>();
                    if (enemy != null)
                    {
                        if (enemy.isDead) return;
                        enemy.StartDamage(damage, transform.position, 0.5f, 0.1f);
                    }
                    break;
                }
            }
        }

        if (isHit)
        {
            ParticleSystem instance = Instantiate(hitEff,transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(instance.gameObject, 1f);

            GetComponent<FallingStarControl>().enabled = false;
        }
    }
}
