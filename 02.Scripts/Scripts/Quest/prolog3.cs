using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;

public class prolog3 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    PlayableDirector timeline;
    public Flowchart dialog;
    public Flowchart dialog2;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player" && QuestProgress.instance.progress == 2)
        {
            EventOn();

            dialog.ExecuteBlock("Prolog3");

            QuestProgress.instance.progress++;
        }
    }

    void EventOn()
    {
        SetStartPos.instance.EventStartPos(character,characterPos);
        
    }
    void TimelineEvent()
    {
        //timeline.Play();
    }
    void TransToNext()
    {
        UIManager.instance.questInfoCompleteButton.onClick.AddListener(() => {

            dialog2.ExecuteBlock("Prolog4");


        });
    }
    
  


}
