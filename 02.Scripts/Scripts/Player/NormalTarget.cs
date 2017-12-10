using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour {

    public List<Collider> targetList;

    

    


     void Awake()
    {
        targetList = new List<Collider>();
        
    }
    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Enemy")
        {
            targetList.Add(other);
        }
     

    }
    
     void OnTriggerStay(Collider other)
    {

        if (other.tag == "Enemy")
        {   
            EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
      
            if (enemy != null && enemy.currentHealth <= 0)
            {       
                targetList.Remove(other);

            }

        }
            

        

      }
     void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);
    }






}
