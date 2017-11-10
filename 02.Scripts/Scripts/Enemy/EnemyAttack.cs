using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float normalDamage = 10f;
    public float skillDamage = 30f;

    public List<Collider> targetList;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetList.Add(other);
        }
    }

     void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            targetList.Remove(other);
        }
    }

     void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null && playerController.dead)
            {
                targetList.Remove(other);
            }

        }
    }
    public void OnAttack()
    {
        Debug.Log("ATtack");
       foreach(Collider one in targetList)
        {
            PlayerController playerController = one.GetComponent<PlayerController>();

            if(playerController != null)
            {
                if (playerController.dead) return;

                playerController.OnDamage(normalDamage);
            }
        }
    }



}
