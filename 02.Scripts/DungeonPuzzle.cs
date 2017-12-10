using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPuzzle : MonoBehaviour {

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }

}

