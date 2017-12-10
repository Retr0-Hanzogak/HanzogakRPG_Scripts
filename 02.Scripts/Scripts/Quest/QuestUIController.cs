using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIController : MonoBehaviour {

    private Camera myCamera;
    private void Start()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        Vector3 v = myCamera.transform.position - transform.position;
        v.x = v.z = 0;
        
        transform.LookAt(myCamera.transform.position - v);

        transform.Rotate(0, 180, 0);
    }
}
