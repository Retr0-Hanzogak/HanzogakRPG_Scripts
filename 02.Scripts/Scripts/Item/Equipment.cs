using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;
    

    public override void Use()
    {
        EQ_Manager.instance.gameObject.SendMessage(base.name.ToString());

        this.isEquipment = true;
                    
        EquipmentManger.instance.Equipment(this);
     
        //Debug.Log("Change Ok");
    }
    
}
public enum EquipmentSlot { Head, Body, Hand, Weapon, Leg, Foot }

