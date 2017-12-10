using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public bool contactPlayer;

    

    public Item[] item;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            contactPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            contactPlayer = false;
        }
    }
    public void PickUp()
    {
        for (int i = 0; i < item.Length; i++)
        {
            Debug.Log("Picking up" + item[i].name);

            PlayerController.main.animator.Play("PickUp", 0);

            bool wasPickedUP = Inventory.instance.Add(item[i]);

            if (!PlayerData.playerItem.ContainsKey(item[i].id)) PlayerData.playerItem.Add(item[i].id, new Item());

            PlayerData.playerItem[item[i].id].amount++;

            

            if (wasPickedUP)
            {
                Destroy(gameObject);
            }

        }
       
    }
    
    

}

