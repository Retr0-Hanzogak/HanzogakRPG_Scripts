using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBallSetUp : MonoBehaviour {

    private Transform player;
    public GameObject rotatingBallPrefab;

    int level;
    int skillNum = 0;
    float setUpYAngle;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        transform.SetParent(null);
        level = SkillData.instance.skillData[skillNum].level;

        setUpYAngle = 360 / (level + 1);

        for(int i = 0; i <= level; i++)
        {
            GameObject instance = Instantiate(rotatingBallPrefab, transform.position, Quaternion.Euler(0, setUpYAngle * i, 0));
            instance.transform.Translate(Vector3.forward * 2);
            instance.transform.SetParent(transform);

            Destroy(instance, 4 + level);
        }
    }

    private void Update()
    {
        transform.position = player.position;
    }
}
