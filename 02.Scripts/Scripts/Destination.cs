using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public Transform[] destinations;

    public float rotSpeed = 5f;

    public GameObject arrow;






     void Update()
    {

        Vector3 dir = arrow.transform.position - destinations[0].position;

        dir.Normalize();

        Quaternion direction = Quaternion.LookRotation(dir);

        

        arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, direction, rotSpeed * Time.deltaTime);


        

        

    }





}
