using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button removeButton;
    public Item item;

  
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

       
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;

        icon.enabled = false;

        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    public void UsetItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
    void Update()
    {
        

        if(item != null && item.isEquipment) 
        {            
             icon.color = Color.red;
             removeButton.interactable = false;
            
        }
        else if(item != null && !item.isEquipment)
        {
            icon.color = Color.white;
            removeButton.interactable = true;
        }
    }

}
