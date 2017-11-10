using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarSetUp : MonoBehaviour {

    public GameObject fallingStarPrefab;

    public LayerMask whatIsEnemy;

    int level;
    int skillNum = 1;
    float range = 10;
    Vector3 fallPos = new Vector3(0, 10, 0);

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        foreach(Collider currentCollider in colliders)
        {
            GameObject instance = Instantiate(fallingStarPrefab, currentCollider.transform.position + fallPos, transform.rotation);

            instance.transform.parent = currentCollider.transform;

            Destroy(instance, SkillData.instance.skillData[skillNum].playTime);
        }
    }
}
