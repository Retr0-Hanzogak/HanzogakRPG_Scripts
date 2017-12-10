using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;
public class Prolog5_0 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    

    public Flowchart dialog;

    public PlayableDirector timeline;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void SetPos()
    {
        SetStartPos.instance.EventStartPos(character, characterPos);
    }
    void EventOn()
    {
        timeline.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" &&QuestProgress.instance.progress == 4)
        {
            dialog.ExecuteBlock("Prolog5_0");

            QuestProgress.instance.progress++;
        }
        
    }

}
