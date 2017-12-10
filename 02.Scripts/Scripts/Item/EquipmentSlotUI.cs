using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{

    public Image icon;
    Equipment equipment;


    public void AddEquipment(Equipment newequipjment)
    {
        equipment = newequipjment;

        icon.sprite = equipment.icon;
        icon.enabled = true;

    }
    public void ClearSlot()
    {
        equipment = null;

        icon.sprite = null;

        icon.enabled = false;


    }

}
