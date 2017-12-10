using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;

public class Prolog2_3 : MonoBehaviour
{
    private PlayableDirector timeline;

    public Transform playerPos;//집안
    public Transform tigerPos;//집안
    public Transform playerPos2;//집밖
    public Transform tigerPos2;//집밖

    public GameObject player;
    public GameObject tiger;
    public Flowchart dialog;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        
    }

    void EvnetOnHouse()
    {
        dialog.ExecuteBlock("Prolog2_3");
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
    void EventOn()//과수원으로 카메라 보내기
    {
        timeline.Play();
    }
}
