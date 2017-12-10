using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public static Inventory instance;

    public int space = 20;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public List<Item> itemsInfo = new List<Item>();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(itemsInfo.Count >= space)
            {
                Debug.Log("Not Enough room.");
                return false;
            }
            itemsInfo.Add(item);
            
            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        itemsInfo.Remove(item);

        if (PlayerData.playerItem.ContainsKey(item.id))
        {
            if(PlayerData.playerItem[item.id].amount > 1)
            {
                PlayerData.playerItem[item.id].amount--;
                //Debug.Log(PlayerData.playerItem[item.id].amount);
            }
            else if(PlayerData.playerItem[item.id].amount == 1)
            {
                PlayerData.playerItem.Remove(item.id);
            }
           
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
