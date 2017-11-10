using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{

    public float maxHealth = 100;

    private Animator animator;

    public float lookHp;

    private bool p_isDead = false;

    public float health
    {
        get;
        private set;
    }

    public bool isDead
    {
        get
        {
            return p_isDead;
        }
        set
        {
            GetComponent<Rigidbody>().isKinematic = value;
            p_isDead = value;
        }
    }
     void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();

    }
    public void OnDamage(float damage)
    {
        if (!isDead)
            return;
        health -= damage;
        animator.Play("Hit", 1);

        if(health <= 0f)
        {
            isDead = true;
            SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
        }
    }
    public void StartDamage(float damage, Vector3 playerPosition, float delay, float pushBack)
    {


        Debug.Log("OK");

        try
        {
            OnDamage(damage);
            Vector3 diff = playerPosition - transform.position;
            diff = diff / diff.sqrMagnitude;
            GetComponent<Rigidbody>().AddForce((transform.position - new Vector3(diff.x, diff.y, 0f)) * 10f * pushBack);

        }
        catch (MissingReferenceException e)
        {
            Debug.Log(e.ToString());
        }

    }
    public void OnDeath()
    {

        GetComponent<Animator>().SetBool("Dead", true);

    }
  

}
