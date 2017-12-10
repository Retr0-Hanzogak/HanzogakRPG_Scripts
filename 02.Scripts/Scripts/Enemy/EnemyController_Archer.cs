using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Archer : MonoBehaviour {

    public GameObject projectile;

    private Transform player;
    private NavMeshAgent agent;
    private Animation anim;

    bool attackDelayCheck = true;
    bool detectAble = false;
    float chaseTime;
    float attackDelay = 2f;
    float senceRange = 10f;
    float attackRange = 7f;
    float distance;

    public float normalDamage = 1f;

    Vector3 originPos;

    EnemyHealth eh;

    private void Start()
    {
        anim = GetComponent<Animation>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        eh = GetComponent<EnemyHealth>();

        originPos = transform.position;
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    private void OnEnable()
    {
        originPos = transform.position;
    }

    IEnumerator AttackDelayStart()
    {
        attackDelayCheck = false;

        yield return new WaitForSeconds(attackDelay);

        attackDelayCheck = true;
    }

    void UpdateTarget()
    {
        if (eh.isDead) return;

        if (PlayerController.main.dead) return;

        distance = Vector3.Distance(transform.position, player.position);

        if (attackDelayCheck)
        {
            if (agent.velocity.magnitude > 0.01f)
            {
                SetAnimation("run");
            }
            else
            {
                SetAnimation("idle");
            }
        }

        if (distance < attackRange)
        {
            detectAble = true;
            agent.isStopped = true;

            if (attackDelayCheck)
            {
                Attack();
                StartCoroutine(AttackDelayStart());
            }
        }
        else
        {
            agent.isStopped = false;
        }

        if (distance < senceRange && distance >= attackRange)
        {
            detectAble = true;

            agent.SetDestination(player.position);
        }
        else if (distance >= senceRange)
        {
            if (detectAble)
            {
                chaseTime = Time.time;
                detectAble = false;
            }
            if (Time.time >= (chaseTime + 3f))
            {
                agent.SetDestination(originPos);
            }
        }
    }

    void Attack()
    {
        SetAnimation("attack");
        transform.LookAt(player);
        GameObject attackInstance = Instantiate(projectile, transform.position, transform.rotation);
        Destroy(attackInstance, 10f);
    }

    void SetAnimation(string aniName)
    {
        anim.CrossFade(aniName);
    }
}
