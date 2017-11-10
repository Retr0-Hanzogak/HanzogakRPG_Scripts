﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Prolog2_1 : MonoBehaviour
{

    public PlayableDirector timeline;
    public GameObject monster;
    public GameObject dialog;
    public Transform evnetPos;

    public GameObject player;

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();


    }
    void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player" && QuestProgress.instance.progress == 1)
        {


            player.transform.position = evnetPos.position;
            player.transform.rotation = evnetPos.rotation;

            dialog.SetActive(true);

            SetStartPos.instance.EventStartPos(character, characterPos);

            QuestProgress.instance.progress++;

        }
        
    }
    void TimeLineStart()
    {
        if (QuestProgress.instance.progress == 2)
            timeline.Play();

        
    }
    



}


