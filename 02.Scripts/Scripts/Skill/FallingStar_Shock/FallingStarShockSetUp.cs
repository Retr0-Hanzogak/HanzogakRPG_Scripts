using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarShockSetUp : MonoBehaviour {

    public GameObject fallingStarShockPrefab;

    public LayerMask whatIsEnemy;

    int level;
    int skillNum = 3;
    float range = 10;
    Vector3 fallPos = new Vector3(0, 10, 0);

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;
        range += level - 1;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        foreach (Collider currentCollider in colliders)
        {
            GameObject instance = Instantiate(fallingStarShockPrefab, currentCollider.transform.position + fallPos, transform.rotation);

            instance.transform.parent = currentCollider.transform;

            Destroy(instance, SkillData.instance.skillData[skillNum].playTime);
        }
    }
}
