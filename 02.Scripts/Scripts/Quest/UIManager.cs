using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Transform canvas;
    public Transform questInfo;
    public Transform questInfoContent;
    public Button questInfoAcceptButton;
    public Transform QuestBookContent;
    public Button questInfoCancelButton;
    public Transform questBook;
    public Button questInfoCompleteButton;

    public Transform skillBook;
    public Text[] skillLv_UI = new Text[10];
    public Text sp_UI;

    public Transform playerInfo;
    public Text playerCombo;
    public Transform questAlarm;

    public Transform menu;
    public Transform equipment;

    //Equipmnet
    public Transform head;
    public Transform body;
    public Transform arm;
    public Transform leg;
    public Transform foot;
    public Transform weapon;

    public Transform[] onoffUI;
     void Awake()
    {
        if (instance == null)
            instance = this;


        canvas = GameObject.Find("Canvas").transform;
        questInfo = canvas.Find("QuestInfo");
        questInfoContent = questInfo.Find("Background/Info/Viewport/Content");
        questInfoAcceptButton = questInfo.Find("Background/Buttons/Accept").GetComponent<Button>();
        QuestBookContent = canvas.Find("QuestBook/Background/Info/Viewport/Content");
        questBook = canvas.Find("QuestBook");
        questInfoCompleteButton = questInfo.Find("Background/Buttons/Complete").GetComponent<Button>();
        questInfoCancelButton = questInfo.Find("Background/Buttons/Cancel").GetComponent<Button>();
        menu = GameObject.Find("Menu/MenuList").transform;
        skillBook = canvas.Find("SkillBook");
        equipment = canvas.Find("Equipment");

        head = equipment.Find("HeadSlot/Head");
        body = equipment.Find("BodySlot/Body");
        arm = equipment.Find("ArmSlot/Arm");
        leg = equipment.Find("LegSlot/Leg");
        foot = equipment.Find("FootSlot/Foot");
        weapon = equipment.Find("WeaponSlot/Weapon");

        for (int i = 0; i < 10; i++)
        {
            skillLv_UI[i] = skillBook.Find("Info/Viewport/Content/Skill (" + i + ")/Text_Lv").GetComponent<Text>();
        }
        sp_UI = skillBook.Find("SP").GetComponent<Text>();

        playerInfo = canvas.Find("CharacterInfo");
        playerCombo = canvas.Find("Combo").GetComponent<Text>();
        
       ActionCancel();

        
       


    }
    void ActionCancel()
    {
        questInfoCancelButton.onClick.AddListener(() =>
        {
            questInfo.gameObject.SetActive(false);
        });
    }

    void TurnOffCancelButton()
    {
        UIManager.instance.questInfoCancelButton.gameObject.SetActive(false);
    }
    void TurnOnAcceptButton()
    {
        UIManager.instance.questInfoAcceptButton.gameObject.SetActive(true);
    }
    void TurnOnCompleteButton()
    {
        UIManager.instance.questInfoCompleteButton.gameObject.SetActive(true);
    }

 
    void TurnOffUI()
    {
     
        for(int i = 0; i < onoffUI.Length; i++)
        {
            onoffUI[i].gameObject.SetActive(false);
        }
    }
    void TurnOnUI()
    {
        for (int i = 0; i < onoffUI.Length; i++)
        {
            onoffUI[i].gameObject.SetActive(true);
        }
    }
}
