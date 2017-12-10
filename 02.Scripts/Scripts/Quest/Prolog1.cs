using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog1 : MonoBehaviour {

    public Transform player;
    public Transform startPos;

    void Start () {

       

        player.position = startPos.position;
        player.rotation = startPos.rotation;

		
	}
	
	
}
