using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;
public class Prolog2 : MonoBehaviour {

    
   
    public Flowchart dialog;

    public PlayableDirector timeline;

     void Start()
    {
        timeline = GetComponent<PlayableDirector>();

    }
     void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && QuestProgress.instance.progress == 0)
        {


            dialog.ExecuteBlock("Prolog2");



            QuestProgress.instance.progress++;
        }
       
    }
    void EventOn()
    {
        timeline.Play();
    }
   
    
   


}
