using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    bool attackDelayCheck = true;
    float attackDelay = 1.5f;
    float senceRange = 10f;
    float attackRange = 3f;
    float distance;

    public float normalDamage = 1f;
    public float skillDamage = 30f;

    public bool isAttack = false;

    Vector3 originPos;

    EnemyHealth eh;


    

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        eh = GetComponent<EnemyHealth>();
        originPos = transform.position;
        
    }

    IEnumerator Attack()
    {
        

        attackDelayCheck = false;

        yield return new WaitForSeconds(attackDelay);

        attackDelayCheck = true;

    }
   


    void UpdateTarget()
    {
        if (!RabbitControl.rabbitMove) return;

        if (eh.isDead) return;

        if (PlayerController.main.dead) return;

        animator.SetFloat("Speed", agent.velocity.magnitude);

        distance = Vector3.Distance(transform.position, player.position);



        if (distance < attackRange)
        {
            agent.isStopped = true;

            transform.LookAt(player);

            if (attackDelayCheck)
            {


                animator.SetBool("Attack", true);

                StartCoroutine(Attack());
            }
            else
            {

                animator.SetBool("Attack", false);


            }
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("Attack", false);
        }

        if (distance < senceRange && distance >= attackRange)
        {
            agent.isStopped = false;

            transform.LookAt(player);

            agent.SetDestination(player.position);
        }
        else if (distance >= senceRange)
        {
            agent.SetDestination(originPos);
        }


    }
   
    public void OnAttack()
    {
        if (isAttack)
        {
            PlayerController.main.OnDamage(normalDamage);
        }     
    
    }
    


}
