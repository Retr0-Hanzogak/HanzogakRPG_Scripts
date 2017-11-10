using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex : MonoBehaviour {

    public int locationId;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!PlayerData.getDestination.ContainsKey(locationId)) PlayerData.getDestination.Add(locationId, new PlayerData.Destination());

            PlayerData.getDestination[locationId].amount++;
        }
    }
}
