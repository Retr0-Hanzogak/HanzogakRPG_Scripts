using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Prolog5_2 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    public List<Transform> recharacterPos = new List<Transform>();

    public Flowchart dialog;

    public GameObject house;

    void SetPos()
    {
        SetStartPos.instance.EventStartPos(character, characterPos);
    }

     void OnTriggerEnter(Collider other)
    {
        

        if(other.tag == "Player" && QuestProgress.instance.progress == 6)
        {
            dialog.ExecuteBlock("Prolog5_2");

            InHouse();

            SetPos();

            QuestProgress.instance.progress++;
        }
    }
    void RePos()
    {
        SetStartPos.instance.EventStartPos(character, recharacterPos);
    }
    void InHouse()
    {
        house.SetActive(true);
    }
    void OutHouse()
    {
        house.SetActive(false);
    }
}
