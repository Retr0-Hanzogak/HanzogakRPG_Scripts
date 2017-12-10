using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog4 : MonoBehaviour {

    public GameObject house;

	// Use this for initialization
	void Start () {
		
	}
	
	void ChangeColor()
    {
        house.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    
}
