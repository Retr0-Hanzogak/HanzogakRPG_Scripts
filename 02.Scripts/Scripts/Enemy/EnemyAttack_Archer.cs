using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_Archer : MonoBehaviour {

    public float normalDamage = 1;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            return;
        }

        if(other.tag == "Player")
        {
            PlayerController.main.OnDamage(normalDamage);
        }

        Destroy(gameObject);
    }
}
