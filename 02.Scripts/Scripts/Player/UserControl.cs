using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

  
    private PlayerAttack playerAttack;
    float lastAttackTime, lastSkillTime;
    public float rotSpeed = 10f;

    public GameObject dungeon;

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
        
        
        

        //스킬
        //SkillTestAddSP(); 모바일로 바꾸면서 수정함

        //이벤트 들어갈때 움직임 제어
        if (!playerMove) return;

        //공격 애니메이션 발동시 이동 막기 모바일 빌드 하면서 주석처리함
        /*
        if (!PlayerController.main.isAttack)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        */

       
        //마우스 좌클릭 우클릭시 UI클릭하면 공격안하고 나가게 하기 모바일 로 바꾸면서 필요없어짐
        /*
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0)) return;

        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1)) return;
        */
       //NPC클릭시 이용
        PlayerController.main.GetInput();
       
        //이벤트씬 들어갈때 행동 X
        /*
        if (playerMove == true)
        {
            //LightAttack();
            //HeaveyAttack();
            //OnSliding();
            //Defense();
        }

        */



    }
    public void OnStickChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    public void InputLightAttack()
    {
        if(playerMove == true && PlayerController.main.isEquipped == true)
        {
            SendMessage("OnAttack", PlayerController.Attack_State.LIGHT_ATTACK, SendMessageOptions.DontRequireReceiver);

            return;
        }
    }

    void GetSkillInput(int num)
    {
        if(playerMove == true)
        {
            SkillManager.instance.SkillSet(num);
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
        if (h == 0 && v == 0) return;
           
        if (PlayerController.main.isAttack) return;

        if(movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);

            playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, rotSpeed * Time.deltaTime);
        }


    }
    public void OnOffQuestList()
    {
        if (!UIManager.instance.questBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.questBook.gameObject.SetActive(true);
            QuestManager.instance.ShowActiveQuests();

        }
        else if (UIManager.instance.questBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.questBook.gameObject.SetActive(false);
        }

    }

    public void OnOffSkillList()
    {
        if (!UIManager.instance.skillBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.skillBook.gameObject.SetActive(true);

        }
        else if (UIManager.instance.skillBook.gameObject.activeInHierarchy)
        {
            UIManager.instance.skillBook.gameObject.SetActive(false);
        }
    }
    public void OnOffMenuList()
    {
        if (!UIManager.instance.menu.gameObject.activeInHierarchy)
        {
            UIManager.instance.menu.gameObject.SetActive(true);
        }
        else if (UIManager.instance.menu.gameObject.activeInHierarchy)
        {
            UIManager.instance.menu.gameObject.SetActive(false);
        }



    }
    public void OnOffEquipment()
    {
        if (!UIManager.instance.equipment.gameObject.activeInHierarchy)
        {
            UIManager.instance.equipment.gameObject.SetActive(true);
        }
        else if (UIManager.instance.equipment.gameObject.activeInHierarchy)
        {
            UIManager.instance.equipment.gameObject.SetActive(false);
        }

    }

    public void SkillTestAddSP()
    {      
            SkillManager.instance.AddSP();
    }
    

}
