using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id = 0;

    new public string name = "New String";

    public int amount;

    public Sprite icon = null;

    public bool showInInventory = true;

    public bool isDefaultItem = false;

    public float hpPlus;

    public bool isEquipment;// 장비를 위한 불리언..다른방법이 없어서 여기다가 집어넣음

    public virtual void Use() //소비아이템
    {
        if(hpPlus>0)
        {
            PlayerController.main.SetHealth(PlayerController.main.currentHealth + hpPlus);
        }

        Inventory.instance.Remove(this);


    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}