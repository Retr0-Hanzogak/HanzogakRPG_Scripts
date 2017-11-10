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

        skillBook = canvas.Find("SkillBook");
        for (int i = 0; i < 10; i++)
        {
            skillLv_UI[i] = skillBook.Find("Info/Viewport/Content/Skill (" + i + ")/Text_Lv").GetComponent<Text>();
        }
        sp_UI = skillBook.Find("SP").GetComponent<Text>();

        playerInfo = canvas.Find("CharacterInfo");

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
        playerInfo.gameObject.SetActive(false);
    }
    void TurnOnUI()
    {
        playerInfo.gameObject.SetActive(true);
    }
}
