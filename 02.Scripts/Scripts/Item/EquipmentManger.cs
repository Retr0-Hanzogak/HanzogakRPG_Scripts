using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentManger : MonoBehaviour {

    public static EquipmentManger instance;


    //UI
    public Image head;
    public Image body;
    public Image leg;
    public Image foot;
    public Image arm;
    public Image weapon;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        head = UIManager.instance.head.GetComponent<Image>();
        body = UIManager.instance.body.GetComponent<Image>();
        leg = UIManager.instance.leg.GetComponent<Image>();
        foot = UIManager.instance.foot.GetComponent<Image>();
        arm = UIManager.instance.arm.GetComponent<Image>();
        weapon = UIManager.instance.weapon.GetComponent<Image>();
    }

    public List<Equipment> currentEquipment = new List<Equipment>();



    public void Equipment(Equipment equipment)
    {
            if (currentEquipment.Contains(equipment)) return;  
            
            if(equipment.equipSlot == EquipmentSlot.Body)
            {
                
                for(int i=0; i < currentEquipment.Count; i++)
                {
                    if(currentEquipment[i].equipSlot == EquipmentSlot.Body)
                    {
                        currentEquipment[i].isEquipment = false;
                        currentEquipment.Remove(currentEquipment[i]);
                        
                    }
                    
                }                                   
                body.enabled = true;
                body.sprite = equipment.icon;
            }

            if (equipment.equipSlot == EquipmentSlot.Hand)
            {
            for (int i = 0; i < currentEquipment.Count; i++)
            {
                if (currentEquipment[i].equipSlot == EquipmentSlot.Hand)
                {
                    currentEquipment[i].isEquipment = false;
                    currentEquipment.Remove(currentEquipment[i]);

                }

            }
                arm.enabled = true;
                arm.sprite = equipment.icon;
            }
            if (equipment.equipSlot == EquipmentSlot.Leg)
            {
            for (int i = 0; i < currentEquipment.Count; i++)
            {
                if (currentEquipment[i].equipSlot == EquipmentSlot.Leg)
                {
                    currentEquipment[i].isEquipment = false;
                    currentEquipment.Remove(currentEquipment[i]);

                }

            }

                leg.enabled = true;
                leg.sprite = equipment.icon;
            }
           if (equipment.equipSlot == EquipmentSlot.Foot)
            {
            for (int i = 0; i < currentEquipment.Count; i++)
            {
                if (currentEquipment[i].equipSlot == EquipmentSlot.Foot)
                {
                    currentEquipment[i].isEquipment = false;
                    currentEquipment.Remove(currentEquipment[i]);

                }

            }

                foot.enabled = true;
                foot.sprite = equipment.icon;
            }

             if (equipment.equipSlot == EquipmentSlot.Weapon)
            {
                for (int i = 0; i < currentEquipment.Count; i++)
                {
                    if (currentEquipment[i].equipSlot == EquipmentSlot.Weapon)
                    {
                        currentEquipment[i].isEquipment = false;
                        currentEquipment.Remove(currentEquipment[i]);

                    }

                }



                weapon.enabled = true;
                weapon.sprite = equipment.icon;
            }
            currentEquipment.Add(equipment);

    }
       
    }
    


