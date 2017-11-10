using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour {

    public int npcId;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!PlayerData.npcContacted.ContainsKey(npcId)) PlayerData.npcContacted.Add(npcId, new PlayerData.NpcContact());

             PlayerData.npcContacted[npcId].amount++;

          
        }
       
     
    }
}
