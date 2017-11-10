using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog2_3 : MonoBehaviour
{


    public Transform playerPos;//집안
    public Transform tigerPos;//집안
    public Transform playerPos2;//집밖
    public Transform tigerPos2;//집밖

    public GameObject player;
    public GameObject tiger;
    public GameObject dialog;

    void EvnetOnHouse()
    {
        dialog.SetActive(true);
        
    }

    void PlayerMoveInEvent()
    {
        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;

        tiger.transform.position = tigerPos.position;
        tiger.transform.rotation = tigerPos.rotation;
    }
    void MoveOutHouse()
    {
        player.transform.position = playerPos2.position;
        player.transform.rotation = playerPos2.rotation;

        tiger.transform.position = tigerPos2.position;
        tiger.transform.rotation = tigerPos2.rotation;
    }
}
