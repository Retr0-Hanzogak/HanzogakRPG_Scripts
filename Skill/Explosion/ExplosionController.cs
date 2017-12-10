using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public GameObject hitEff;
    public LayerMask whatIsEnemy;

    int level;
    int skillNum = 4;
    float damage;

    List<Collider> existColliders = new List<Collider>();

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;
        damage = SkillData.instance.skillData[skillNum].firstDamage * Mathf.Pow(SkillData.instance.skillData[skillNum].increaseDamageRatePerLevel, level - 1);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f, whatIsEnemy);

        foreach (Collider currentCollider in colliders)
        {
            if (!existColliders.Contains(currentCollider))
            {
                existColliders.Add(currentCollider);

                EnemyHealth enemy = currentCollider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    if (enemy.isDead) return;

                    enemy.StartDamage(damage, transform.position, 0.5f, 0.1f);

                    GameObject hitEffinstance = Instantiate(hitEff, currentCollider.transform.position, transform.rotation);

                    Destroy(hitEffinstance, 1f);
                }
            }
        }
    }
}
