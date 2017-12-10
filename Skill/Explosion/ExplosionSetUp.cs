using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSetUp : MonoBehaviour {

    public ParticleSystem readyEff;
    public GameObject projectile;

    int level;
    int skillNum = 4;

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            readyEff.Stop();
            GameObject instanceProjectile = Instantiate(projectile, transform.position + new Vector3(0, 1, 0), transform.rotation);
            Destroy(instanceProjectile, 5f);
            Destroy(gameObject);
        }
    }
}
