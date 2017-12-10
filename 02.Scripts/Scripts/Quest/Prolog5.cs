using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Prolog5 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();



    public Flowchart dialog;


    void SetPos()
    {
        SetStartPos.instance.EventStartPos(character, characterPos);
    }
   
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" &&QuestProgress.instance.progress == 3)
        {
            dialog.ExecuteBlock("Prolog5");

            QuestProgress.instance.progress++;
        }
        
    }
    public void GoToHouse()
    {
        QuestProgress.instance.goToHouse = true;
    }
    public void IgonreHouse()
    {
        QuestProgress.instance.goToHouse = false;

        QuestProgress.instance.progress++;
    }

}
