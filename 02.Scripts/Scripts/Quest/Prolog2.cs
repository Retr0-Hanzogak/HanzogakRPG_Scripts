using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Prolog2 : MonoBehaviour {

    
   
    public GameObject dialog;

    

     void Start()
    {
        

    }
     void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && QuestProgress.instance.progress == 0)
        {

            
            dialog.SetActive(true);



            QuestProgress.instance.progress++;
        }
       
    }
   
    
   


}
