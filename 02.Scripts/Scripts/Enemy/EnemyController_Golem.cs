using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Golem : MonoBehaviour {

    public List<GameObject> angryTrails = new List<GameObject>();
    public ParticleSystem awakeEff;
    public ParticleSystem angryEff;

    private Transform player;
    private NavMeshAgent agent;
    private Animation anim;

    bool isAngry = false;
    bool isAwake = false;
    bool isSleep = true;
    bool attackDelayCheck = true;
    bool detectAble = false;
    float chaseTime;
    float awakeDelay = 1f;
    float attackDelay = 1f;
    float senceRange = 10f;
    float attackRange = 3f;
    float distance;

    public float normalDamage = 1f;

    Vector3 originPos;

    EnemyHealth eh;

    void Start()
    {
        anim = GetComponent<Animation>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        eh = GetComponent<EnemyHealth>();

        anim["idle"].wrapMode = WrapMode.Loop;
        anim["walk"].wrapMode = WrapMode.Loop;
        anim["sleep"].wrapMode = WrapMode.Loop;


        originPos = transform.position;
        SetAnimation("sleep");
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    private void OnEnable()
    {
        isAngry = false;
        isAwake = false;
        isSleep = true;
        SetAnimation("sleep");
        originPos = transform.position;
    }

    IEnumerator AttackDelayStart()
    {
        attackDelayCheck = false;

        yield return new WaitForSeconds(attackDelay);

        attackDelayCheck = true;
    }

    IEnumerator AngryTime()
    {
        attackDelayCheck = false;
        SetAnimation("rage");
        yield return new WaitForSeconds(awakeDelay);

        attackDelayCheck = true;
    }

    IEnumerator AwakeTime()
    {
        isSleep = false;

        yield return new WaitForSeconds(awakeDelay);

        isAwake = true;
    }

    void UpdateTarget()
    {
        if (eh.isDead) return;

        if (PlayerController.main.dead) return;

        distance = Vector3.Distance(transform.position, player.position);

        if(!isAngry && eh.currentHealth < eh.startingHealth / 2)
        {
            isAngry = true;
            foreach(GameObject tmp in angryTrails)
            {
                tmp.SetActive(true);
            }
            angryEff.Play();
            StartCoroutine(AngryTime());
            agent.speed *= 1.5f;
        }

        if (isSleep)
        {
            if(distance < senceRange/2)
            {
                awakeEff.Play();
                SetAnimation("sleep_end");
                StartCoroutine(AwakeTime());
            }
        }
        if (isAwake)
        {
            if (attackDelayCheck)
            {
                if (agent.velocity.magnitude > 0.01f)
                {
                    SetAnimation("walk");
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
    }

    void Attack()
    {
        transform.LookAt(player);
        PlayerController.main.OnDamage(normalDamage);
        if (isAngry)
        {
            SetAnimation("hit");
        }
        else
        {
            SetAnimation("hit2");
        }
    }

    void SetAnimation(string aniName)
    {
        anim.CrossFade(aniName);
    }
}