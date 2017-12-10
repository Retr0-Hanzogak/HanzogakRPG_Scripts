using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Prolog5_1 : MonoBehaviour {

    public Flowchart dialog;
    

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();



    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && QuestProgress.instance.progress == 5 && QuestProgress.instance.goToHouse)
        {
            dialog.ExecuteBlock("Prolog5_1");

            SetStartPos.instance.EventStartPos(character, characterPos);

            QuestProgress.instance.progress++;
        }

        
    }
}
