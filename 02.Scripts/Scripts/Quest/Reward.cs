using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour {

    public Item[] item;

    public Equipment[] firstequipments; //게임시작시 디폴트 장비
   

    public void RewardItem()
    {
        for (int i = 0; i < item.Length; i++)
        {           
            bool wasPickedUP = Inventory.instance.Add(item[i]);

            if (!PlayerData.playerItem.ContainsKey(item[i].id)) PlayerData.playerItem.Add(item[i].id, new Item());

            PlayerData.playerItem[item[i].id].amount++;

            //Debug.Log(PlayerData.playerItem[item[i].id].amount);      

        }

    }
    public void ForceEquipment() // 게임시작시 초기 장비 주고 바로 착용시키는 것
    {

        for(int i =0; i < item.Length; i++)
        {          
            
           item[i].isEquipment = false;          
            
        }

        

        for (int i = 0; i < firstequipments.Length; i++)
        {
            bool wasPickedUP = Inventory.instance.Add(firstequipments[i]);

            firstequipments[i].Use();

            //EquipmentManger.instance.currentEquipment.Add(firstequipments[i]);

            if (!PlayerData.playerItem.ContainsKey(firstequipments[i].id)) PlayerData.playerItem.Add(firstequipments[i].id, new Equipment());

            PlayerData.playerItem[firstequipments[i].id].amount++;

            //Debug.Log(PlayerData.playerItem[firstequipments[i].id].amount);

        }
    }


}
