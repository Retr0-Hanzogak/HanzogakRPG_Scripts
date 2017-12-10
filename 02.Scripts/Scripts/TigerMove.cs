using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TigerMove : MonoBehaviour {

    private Transform player;
    public float distance;
   
    private float chaseRange = 10f;
    private float minChaseRange = 3f;

    public  NavMeshAgent agent;
    public Animator ani;
    public float rotSpeed = 1f;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
       
    }
    void GetTiger() //이벤트 후 호랑이와 모험을 떠나면 발동하는 함수
    {

        agent.enabled = true;
        StartCoroutine(ChasePlayer());
    }
    private void OnEnable()
    {
        if (agent.enabled == true)
        {
            StartCoroutine(ChasePlayer());
        }

    }

    IEnumerator ChasePlayer()
    {
        
        while (true) //게임오버 관련 bool 나오면 그걸로 교체
        {
            distance = Vector3.Distance(transform.position, player.position);          

            if (distance <= chaseRange && distance > minChaseRange && UserControl.playerMove)
            {
                agent.isStopped = false;

                Vector3 movement = player.position - transform.position;

                movement.Normalize();

                Quaternion direction = Quaternion.LookRotation(movement);

                transform.rotation = Quaternion.Slerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

                ani.SetBool("Run", true);

                agent.SetDestination(player.position);
            }
            else if(distance > chaseRange && UserControl.playerMove)
            {
                agent.isStopped = true;

                ani.SetBool("Run", false);

                ani.Play("Idle", 0);


            }
            else if(distance < minChaseRange && UserControl.playerMove)
            {

                agent.isStopped = true;

                ani.SetBool("Run", false);

                ani.Play("Idle", 0);



            }

            yield return new WaitForSeconds(0.1f);
        }
        
       
        

    }
}
