using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

  
    private PlayerAttack playerAttack;
    float lastAttackTime, lastSkillTime;
    public float rotSpeed = 10f;

    public float h;
    public float v;

    public float moveSpeed = 10f;
    
    public Animator animator;
    Rigidbody playerRigidbody;

    Vector3 movement;

    public bool contatctNpc;

    public static bool playerMove;//이벤트 씬 돌입시 플레이어의 행동을 막기위한 bool

    string currentStateName = "";

     void Awake()
    {
        
    }
     void Start()
    {
        
        playerAttack = GetComponent<PlayerAttack>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerMove = true;
        
    }
   
    void Update()
    {

        //UI관련
        OnOffQuestList();
        OnOffSkillList();

        //스킬
        SkillTest0();
        SkillTest1();
        SkillTest2();
        SkillTest3();
        //SkillTest4();
        SkillTest5();
        //SkillTest6();
        SkillTest7();
        SkillTest8();
        //SkillTest9();
        SkillTestAddSP();

        //이벤트 들어갈때 움직임 제어
        if (!playerMove) return;

        //공격 애니메이션 발동시 이동 막기
        if (!PlayerController.main.isAttack)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

       
        //마우스 좌클릭 우클릭시 UI클릭하면 공격안하고 나가게 하기
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0)) return;

        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1)) return;

       //NPC클릭시 이용
        PlayerController.main.GetInput();
       
        //이벤트씬 들어갈때 행동 X
        if (playerMove == true)
        {
            LightAttack();
            HeaveyAttack();
            OnSliding();
            Defense();
        }

   



    }

    public void LightAttack()
    {
        
        
        if (Input.GetButtonDown("Fire1") && PlayerController.main.isEquipped == true) // 왼쪽 마우스 누르면 발동하는 일반 공격
        {
            SendMessage("OnAttack", PlayerController.Attack_State.LIGHT_ATTACK, SendMessageOptions.DontRequireReceiver);

            return;
            
        }
        
    }
    void HeaveyAttack()
    {
        if (Input.GetButtonDown("Fire2") && PlayerController.main.isEquipped == true) //오른쪽 마우스 누르면 발동, 발차기 + 내려찍기 콤보
        {
            SendMessage("OnAttack", PlayerController.Attack_State.HEAVY_ATTACK, SendMessageOptions.DontRequireReceiver);


            return;
        }
    }
        
    
  
    
    void Defense()
    {
        if (Input.GetKeyDown("c") && PlayerController.main.isEquipped == true) //방어
        {
            SendMessage("OnDefense", SendMessageOptions.DontRequireReceiver);

            return;
        }
    }
    void OnSliding()
    {
        if (
        (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.5f ||
              Mathf.Abs(Input.GetAxis("Vertical")) >= 0.5f)
           && Input.GetButtonDown("Sliding")
          )
        {

            SendMessage("OnSliding", SendMessageOptions.DontRequireReceiver);  // 슬라이딩 하는 스킬 우선은 v로 설정

            return;
        }
    }
    
    
    void FixedUpdate()
    {
        //이벤트 들어갈때 빠져나오기
        if (PlayerController.main.isAttack) return;
        

        // 이벤트 들어갈시 행동X
        if (playerMove == true)
        {
            PlayerMove(h, v);
            PlayerTurn();
            
        }
        
        
    }
  
    public void PlayerMove(float h, float v)
    {
        movement.Set(h, 0, v);
    
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        //playerRigidbody.MovePosition(transform.position + movement);

        animator.SetFloat("Speed", h * h + v * v);
    }
    
 




    void PlayerTurn()
    {
        if (h == 0 && v == 0)
            return;

        if (PlayerController.main.isAttack) return;

        Quaternion newRotation = Quaternion.LookRotation(movement);

        playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, rotSpeed * Time.deltaTime);




    }
    void OnOffQuestList()
    {
        if (Input.GetKeyDown("q") && !UIManager.instance.questBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.questBook.gameObject.SetActive(true);
            QuestManager.instance.ShowActiveQuests();

        }
        else if (Input.GetKeyDown("q") && UIManager.instance.questBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.questBook.gameObject.SetActive(false);
        }

    }

    void OnOffSkillList()
    {
        if (Input.GetKeyDown("y") && !UIManager.instance.skillBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.skillBook.gameObject.SetActive(true);

        }
        else if (Input.GetKeyDown("y") && UIManager.instance.skillBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.skillBook.gameObject.SetActive(false);
        }
    }

    void SkillTest0()
    {
        if (Input.GetKeyDown("0"))
            SkillManager.instance.SkillSet(0);
    }

    void SkillTest1()
    {
        if (Input.GetKeyDown("1"))
            SkillManager.instance.SkillSet(1);
    }

    void SkillTest2()
    {
        if (Input.GetKeyDown("2"))
            SkillManager.instance.SkillSet(2);
    }

    void SkillTest3()
    {
        if (Input.GetKeyDown("3"))
            SkillManager.instance.SkillSet(3);
    }

    void SkillTest4()
    {
        if (Input.GetKeyDown("4"))
            SkillManager.instance.SkillSet(4);
    }

    void SkillTest5()
    {
        if (Input.GetKeyDown("5"))
            SkillManager.instance.SkillSet(5);
    }

    void SkillTest6()
    {
        if (Input.GetKeyDown("6"))
            SkillManager.instance.SkillSet(6);
    }

    void SkillTest7()
    {
        if (Input.GetKeyDown("7"))
            SkillManager.instance.SkillSet(7);
    }

    void SkillTest8()
    {
        if (Input.GetKeyDown("8"))
            SkillManager.instance.SkillSet(8);
    }

    void SkillTest9()
    {
        if (Input.GetKeyDown("9"))
            SkillManager.instance.SkillSet(9);
    }

    void SkillTestAddSP()
    {
        if (Input.GetKeyDown("i"))
            SkillManager.instance.AddSP();
    }
    

}
