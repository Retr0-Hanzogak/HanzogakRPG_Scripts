using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog6 : MonoBehaviour {

    public GameObject dialog;

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && QuestProgress.instance.progress == 6)
        {
            SetStartPos.instance.EventStartPos(character, characterPos);

            dialog.SetActive(true);

            QuestProgress.instance.progress++;
        }

    }
    void LookAtPlayer()
    {
        for(int i=0; i<10; i++)
        {
            character[i].transform.LookAt(characterPos[11]);
        }
    }
}
