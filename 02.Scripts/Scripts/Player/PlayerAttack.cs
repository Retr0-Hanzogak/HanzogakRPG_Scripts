using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public static PlayerAttack instance;

    public float NormalDamage = 10f;
    public float HeavyDamage = 20f;
    public float SkillDamage = 30f;
    public float kickPow = 1000;

    public NormalTarget normalTarget;
    public SkillTarget skillTarget;


    private void Awake()
    {
        instance = this;
    }

    public void NormalAttack() // 공격 애니메이션 발동시 발동하는 함수 애니메이션 이벤트로 처리 -> 검기 생성 기능을 여기 만들되 타이밍이 맞지 않으면 따로 구현후 이벤트로 시기를 맞출것
    {

        List<Collider> targetList = new List<Collider>(normalTarget.targetList); 

        foreach(Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                if (enemy.isDead) return;

                enemy.StartDamage(NormalDamage, transform.position, 0.5f, 0.1f);    
                
                
                
            }
        }
    }
    public void HeaveyAttack()
    {
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        foreach (Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                if (enemy.isDead) return;

                enemy.StartDamage(HeavyDamage, transform.position, 0.5f, 0.1f);



            }
        }
    }
    
    public void Denfense() // 방어 애니메이션 발동시 발동하는 함수
    {
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        foreach (Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                //Defense
            }
        }
    }
    public void Kick() 
    {

        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        foreach (Collider one in targetList)
        {
            Rigidbody enemy = one.GetComponent<Rigidbody>();
            EnemyHealth monster = one.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.AddForce(Vector3.up* kickPow, ForceMode.Impulse);
                monster.OnDamage(NormalDamage);
            }
            
        }
    }
    public void SkillAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);

        foreach(Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            if(enemy!= null)
            {
                enemy.StartDamage(SkillDamage, transform.position, 1f, 2f);
            }
        }
    }
}
