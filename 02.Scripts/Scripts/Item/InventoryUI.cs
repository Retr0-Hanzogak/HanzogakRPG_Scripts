using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform[] itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    InventorySlot[] slots;

    public List<InventorySlot> itemslots = new List<InventorySlot>();

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        for (int i = 0; i< itemsParent.Length; i++)
        {
            slots = itemsParent[i].GetComponentsInChildren<InventorySlot>();

            for(int v =0; v < slots.Length; v++)
            {
                itemslots.Add(slots[v]);
            }
            
        }
        
    }
    public void OnOffUI()
    {
            if (inventoryUI.activeInHierarchy)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else if (!inventoryUI.activeInHierarchy)
            {
                inventoryUI.gameObject.SetActive(true);
            }
     }
    


    void UpdateUI()
    {
        for(int i = 0; i < itemslots.Count; i++)
        {
            if(i < inventory.itemsInfo.Count)
            {
                itemslots[i].AddItem(inventory.itemsInfo[i]);

            }
            else
            {
                itemslots[i].ClearSlot();
            }
        }
    }
    public void PageUp()
    {
        if (itemsParent[0].gameObject.activeInHierarchy)
        {
            itemsParent[0].gameObject.SetActive(false);
            itemsParent[1].gameObject.SetActive(true);
        }
        else if (itemsParent[1].gameObject.activeInHierarchy)
        {
            itemsParent[1].gameObject.SetActive(false);
            itemsParent[2].gameObject.SetActive(true);
        }
        else if (itemsParent[2].gameObject.activeInHierarchy)
        {
            itemsParent[2].gameObject.SetActive(false);
            itemsParent[3].gameObject.SetActive(true);
        }
        else if (itemsParent[3].gameObject.activeInHierarchy)
        {
            itemsParent[3].gameObject.SetActive(false);
            itemsParent[4].gameObject.SetActive(true);
        }
         
    }
    public void PageDown()
    {
        
         if(itemsParent[4].gameObject.activeInHierarchy)
        {
            itemsParent[4].gameObject.SetActive(false);
            itemsParent[3].gameObject.SetActive(true);
        }
        else if (itemsParent[3].gameObject.activeInHierarchy)
        {
            itemsParent[3].gameObject.SetActive(false);
            itemsParent[2].gameObject.SetActive(true);
        }
        else if (itemsParent[2].gameObject.activeInHierarchy)
        {
            itemsParent[2].gameObject.SetActive(false);
            itemsParent[1].gameObject.SetActive(true);
        }
        else if (itemsParent[1].gameObject.activeInHierarchy)
        {
            itemsParent[1].gameObject.SetActive(false);
            itemsParent[0].gameObject.SetActive(true);
        }
        
    }
}
