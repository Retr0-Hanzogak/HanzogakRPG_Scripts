using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Prolog5 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    PlayableDirector timeline;

    public GameObject dialog;

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
        if(other.tag == "Player" &&QuestProgress.instance.progress == 3)
        {
            dialog.SetActive(true);

            QuestProgress.instance.progress++;
        }
        
    }

}
