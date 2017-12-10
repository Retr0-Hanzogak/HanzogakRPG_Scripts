using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashControl : MonoBehaviour {

    public GameObject hitEff;
    public LayerMask whatIsEnemy;

    Transform player;
    float movefloat;

    int skillNum = 7;
    float damage;
    List<Collider> existColliders = new List<Collider>();

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        damage = SkillData.instance.skillData[skillNum].firstDamage * Mathf.Pow(SkillData.instance.skillData[skillNum].increaseDamageRatePerLevel, SkillData.instance.skillData[skillNum].level - 1);

    }

    private void FixedUpdate()
    {
        movefloat += Time.deltaTime * 0.7f;
        player.position = Vector3.Lerp(player.position, player.position + player.forward * 5f, movefloat);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, whatIsEnemy);

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

                    Destroy(hitEffinstance, 0.5f);
                }
            }
        }
    }
}
