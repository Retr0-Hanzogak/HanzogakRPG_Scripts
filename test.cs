using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public List<GameObject> cubes = new List<GameObject>();
    public List<Transform> cubesPos = new List<Transform>();

    
 
    // Use this for initialization
    void Start () {



        for (int i= 0; i <= cubes.Count; i++)
        {
            cubes[i].transform.position = cubesPos[i].transform.position;
        }
        
		
	}
	
	
}
