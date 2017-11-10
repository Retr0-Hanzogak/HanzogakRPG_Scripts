using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarShowerSetUp : MonoBehaviour {

    public GameObject fallingStarShockPrefab;
    public ParticleSystem rangeRing;
    public LayerMask whatIsEnemy;

    int level;
    int skillNum = 5;
    float range = 10;
    Vector3 fallPos = new Vector3(0, 10, 0);

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;
        range += level - 1;
        rangeRing.startSize = range;

        ParticleSystem instanceRing = Instantiate(rangeRing);
        instanceRing.transform.position = transform.position;
        instanceRing.transform.parent = transform;
        Destroy(instanceRing, 10f);

        UpdateTarget();
    }

    void UpdateTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        foreach (Collider currentCollider in colliders)
        {
            StartCoroutine(DelayInstance(currentCollider, Random.Range(0, 0.5f)));
        }
        Invoke("UpdateTarget", Random.Range(0.3f, 0.6f));
    }

    IEnumerator DelayInstance(Collider currentCollider, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Vector3 randomFall = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        GameObject instance = Instantiate(fallingStarShockPrefab, currentCollider.transform.position + fallPos + randomFall, transform.rotation);

        instance.transform.parent = currentCollider.transform;
        Destroy(instance, SkillData.instance.skillData[skillNum].playTime);
    }

}
