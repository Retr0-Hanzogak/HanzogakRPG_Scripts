using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog5_1 : MonoBehaviour {

    public GameObject dialog;

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && QuestProgress.instance.progress == 4)
        {
            dialog.SetActive(true);

            SetStartPos.instance.EventStartPos(character, characterPos);

            QuestProgress.instance.progress++;
        }

        
    }
}
