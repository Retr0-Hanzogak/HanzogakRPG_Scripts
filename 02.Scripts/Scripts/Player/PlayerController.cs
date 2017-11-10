using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable
{


    public static PlayerController main;

    public UserControl uc;

    Rigidbody rb;

    public bool contactPlayer;

    public GameObject sword;
    public GameObject swordParticle;
    public GameObject tiger;

    //레벨업
    public int level = 1;
    public Text levelText;
    public float experience { get; private set; }

    public Transform experienceBar;
    public Transform healthBar;
    public Text healthBartext;

    public float waitTime = 4f; // 호랑이가 검으로 바뀔때 파티클 껐다 키는 대기 시간


    float totalHealth = 150;
    public float currentHealth = 0;

    public bool dead;

    public Animator animator;


    public bool isEquipped;
    public bool isWalking;
    public bool isJumping;
    public bool isAttack = false;
    public bool isHit = false;
    

    


    public enum Attack_State { LIGHT_ATTACK, HEAVY_ATTACK }





    void Start()
    {

        if (main == null) main = this;       

        animator = GetComponent<Animator>();

        uc = GetComponent<UserControl>();

        animator.SetBool("Equipped", true);
        isEquipped = true;
        isWalking = false;

        SetExperience(0);
        SetHealth(totalHealth);


        

    }




    public void OnAttack(Attack_State attackState)
    {
        switch (attackState)
        {
            case Attack_State.LIGHT_ATTACK:
                animator.SetTrigger("Light Attack");


                break;
            case Attack_State.HEAVY_ATTACK:
                animator.SetTrigger("Heavy Attack");

                break;
        }
    }
   


    void OnSliding()
    {
        animator.SetTrigger("Roll");
    }

    void OnSkillAttack()
    {
        animator.SetTrigger("Skill");
    }


    void UnEquipping()
    {
        animator.SetBool("Equipped", false);

        isEquipped = false;
    }


    void Equipping()
    {
        animator.SetBool("Equipped", true);


        isEquipped = true;

    }
    void OnHit()
    {
        isHit = true;
    }
    void OutHit()
    {
        isHit = false;
    }

   
    void OnDefense()
    {
        animator.SetTrigger("Defense");

    }
    
    void PlayerTalkInEvent()
    {
        animator.SetBool("Dialogue", true);
    }

    void PlayerTalkStop()
    {
        animator.SetBool("Dialogue", false);
    }

    public void OnAttackEnter()
    {
        isAttack = true;

        uc.h = 0;

        uc.v = 0;
        
    }
    public void OnAttackExit()
    {
        isAttack = false;
        
    }


    public void SetExperience(float exp)
    {
        experience += exp;
        float experienceNeeded = GameLogic.ExperienceForNextLevel(level);
        float previousExperience = GameLogic.ExperienceForNextLevel(level - 1);
        //Level Up
        if (experience >= experienceNeeded)
        {
            LevelUp();
            experienceNeeded = GameLogic.ExperienceForNextLevel(level);
            previousExperience = GameLogic.ExperienceForNextLevel(level - 1);
        }
        experienceBar.GetComponent<Image>().fillAmount = (experience - previousExperience) / (experienceNeeded - previousExperience);
    }

    void SetHealth(float health)
    {
        if (health > totalHealth) currentHealth = totalHealth;
        else if (health <= 0)
        {
            Die();
            currentHealth = 0;
        }
        else currentHealth = health;
        healthBar.GetComponent<Image>().fillAmount = currentHealth / totalHealth;
        healthBartext.GetComponent<Text>().text = currentHealth + "/" + totalHealth;
    }
    public void OnDamage(float damage)
    {
        if (dead) return;

        

        if (!isHit)
        {
            uc.h = 0;
            uc.v = 0;
            animator.Play("Hit", 0);
        }

        SetHealth(currentHealth - damage);

        
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyAttack")
        {
            GameObject rig = other.transform.parent.gameObject;

            GameObject rabbit = rig.transform.parent.gameObject;

            EnemyController enemyController = rabbit.GetComponent<EnemyController>();

            enemyController.isAttack = true;

        }
        
    }
    

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            GameObject rig = other.transform.parent.gameObject;

            GameObject rabbit = rig.transform.parent.gameObject;

            EnemyController enemyController = rabbit.GetComponent<EnemyController>();



            enemyController.isAttack = false;

        }
    }

    void Die()
    {
        dead = true;

        UserControl.playerMove = false;

        animator.SetTrigger("Dead");
        
    }

    void LevelUp()
    {
        level++;
        levelText.text = "Lv. " + level.ToString("00");
    }
  

    
    public void GetInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Check if is an NPC
                TigerNpcController tigerNpcController = hit.transform.GetComponent<TigerNpcController>();
                if (tigerNpcController != null && PlayerController.main.contactPlayer == true)
                {
                    tigerNpcController.ShowQuestInfo();
                    
                    return;
                }
            }


        }

    }



    // 이벤트용 함수
    IEnumerator ChangeSword()
    {
        if (!swordParticle.activeInHierarchy)
        {
            swordParticle.SetActive(true);
        }
        
        yield return new WaitForSeconds(waitTime);

        tiger.SetActive(false);

        sword.SetActive(true);

        swordParticle.SetActive(false);
     
    }
    IEnumerator ChangeTiger()
    {
        if (!swordParticle.activeInHierarchy)
        {
            swordParticle.SetActive(true);
        }
        yield return new WaitForSeconds(waitTime);

        sword.SetActive(false);

        tiger.SetActive(true);

        swordParticle.SetActive(false);
    }

    void Sword()
    {
        StartCoroutine(ChangeSword());
    }
    void Tiger()
    {
        StartCoroutine(ChangeTiger());
    }
    //이벤트용 함수


}





    




