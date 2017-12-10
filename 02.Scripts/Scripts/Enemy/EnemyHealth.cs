using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int monsterId;
    public float startingHealth = 100;
    public float currentHealth;
    public GameObject hitParticle;
    public float expGranted;

    public bool isDead; // 몬스터 죽었는지 판단
    bool isSinking;
    bool damaged = false;
    public Animator ani;
    private Animation anim;
  
    
    public GameObject players;


    void Awake()
    {
        currentHealth = startingHealth;

    }
     void Start()
    {
        ani = GetComponent<Animator>();
        if (ani == null)
            anim = GetComponent<Animation>();

        players = GameObject.Find("Player").gameObject;

    }

    public void OnDamage(float damage) // 단순히 데미지만 입는 함수
    {
        if (!isDead)
        {
            damaged = true;

            if(ani != null)
            {
                ani.Play("Hit", 0);
            }
            else
            {
                anim.CrossFade("damage");
            }

            currentHealth -= damage;

            StartCoroutine(ComboController());

            ComboManager.instance.playerCombo++;
            ComboManager.instance.ComboPlus();

            

            PlayParticleHit();

            

        }     

        if(currentHealth <= 0)
        {
            

            if(currentHealth<=0)
            {

                isDead = true;

                Death();
               
            }
        }
    }
    
    public void StartDamage(float damage, Vector3 playerPosition, float delay, float pushBack) // 데미지를 입으면서 뒤로 넉백현상을 발동시킴
    {   
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
    
    IEnumerator ComboController()
    {
        ComboManager.instance.doingCombo = true;

        yield return new WaitForSeconds(2.5f);

        ComboManager.instance.doingCombo = false;
    }

    void PlayParticleHit() // 임시->바꿀예정
    {
        GameObject instanceEff = Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(instanceEff, 1f);
    }


    public void Death()
    {

        if (!PlayerData.monsterKilled.ContainsKey(monsterId)) PlayerData.monsterKilled.Add(monsterId, new PlayerData.MonsterKills());

            PlayerData.monsterKilled[monsterId].amount++;

 
            players.GetComponent<PlayerController>().SetExperience(expGranted);
        
            
        if (ani != null)
        {
            ani.SetTrigger("Dead");
        }
        else
        {
            anim.CrossFade("die");
        }


        Invoke("TurnOff", 1.5f);
            
            
    }
    void TurnOff()
    {
        gameObject.SetActive(false);
    }
  


}
