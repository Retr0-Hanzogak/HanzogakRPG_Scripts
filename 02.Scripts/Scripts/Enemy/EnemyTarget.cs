using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{

    public List<Collider> targetList;


    void Awake()
    {
        targetList = new List<Collider>();

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            targetList.Add(other);
        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
           

            if (PlayerController.main.currentHealth <= 0)
            {
                targetList.Remove(other);

            }

        }




    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetList.Remove(other);
        }
    }






}
