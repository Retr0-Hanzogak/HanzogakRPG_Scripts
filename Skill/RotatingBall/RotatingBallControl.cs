using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBallControl : MonoBehaviour {

    private Transform m_Player;
    float damage;
    int skillNum = 0;

    public ParticleSystem hitEff;

    private void Start()
    {
        m_Player = GameObject.Find("Player").GetComponent<Transform>();
        damage = SkillData.instance.skillData[skillNum].firstDamage * Mathf.Pow(SkillData.instance.skillData[skillNum].increaseDamageRatePerLevel, SkillData.instance.skillData[skillNum].level - 1);
    }
    void Update()
    {
        transform.RotateAround(m_Player.position, new Vector3(0, 1, 0), 200 * Time.deltaTime);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (Collider currentCollider in colliders)
        {
            if (currentCollider.tag == "Enemy")
            {
                EnemyHealth enemy = currentCollider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    if (enemy.isDead) return;
                    enemy.StartDamage(damage, transform.position, 0.5f, 0.1f);
                }
                ParticleSystem instance = Instantiate(hitEff, transform.position, Quaternion.Euler(90,0,0));
                instance.transform.SetParent(null);
                Destroy(instance.gameObject, 1f);
                Destroy(gameObject);
            }
        }
    }
}