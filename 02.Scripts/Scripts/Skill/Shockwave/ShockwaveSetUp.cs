using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveSetUp : MonoBehaviour {

    public GameObject shockwavePrefab;
    
    private void Start()
    {
        GameObject instance = Instantiate(shockwavePrefab, transform.position, transform.rotation);

        Destroy(instance, SkillData.instance.skillData[1].playTime);
    }
}
