using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog5_2 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    public List<Transform> recharacterPos = new List<Transform>();

    public GameObject dialog;

    void SetPos()
    {
        SetStartPos.instance.EventStartPos(character, characterPos);
    }

     void OnTriggerEnter(Collider other)
    {
        

        if(other.tag == "Player" && QuestProgress.instance.progress == 5)
        {
            dialog.SetActive(true);

            SetPos();

            QuestProgress.instance.progress++;
        }
    }
    void RePos()
    {
        SetStartPos.instance.EventStartPos(character, recharacterPos);
    }
}
