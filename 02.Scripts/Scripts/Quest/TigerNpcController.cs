using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigerNpcController : MonoBehaviour {

    public int[] quests;

  
    private Transform player;

    public float connectDistance = 5f;

   
    

 

    public GameObject contatctDialog; // 처음 NPC와 접촉했을때 대사
    public GameObject secondcontactDialog; //두번째 이상부터 접촉했을때 대사..or 퀘스트중 대사
    public GameObject questEndDialog; // 퀘스트 완료후 뜨는 대사

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        foreach (int i in quests)
        {
            QuestManager.instance.LoadQuest(i);
        }

    }

    public void ShowQuestInfo()
    {
        foreach(int i in quests)
        {
            if (!PlayerData.finishedQuests.Contains(i) && QuestManager.instance.IsQuestAvailable(i, GameObject.Find("Player").GetComponent<PlayerController>()))
            {
                QuestManager.instance.ShowQuestInfo(QuestManager.instance.questDictionary[quests[i]]);

                if (QuestManager.instance.IsQuestFinished(i))
                {
                    UIManager.instance.questInfoCompleteButton.gameObject.SetActive(true);

                    UIManager.instance.questInfoAcceptButton.gameObject.SetActive(!PlayerData.activeQuests.ContainsKey(i));

               

                    UIManager.instance.questInfoCompleteButton.onClick.AddListener(() => {

                        ReceiveCompletedQuest(QuestManager.instance.questDictionary[quests[i]]);

                        PlayerData.activeQuests.Remove(i);
                        PlayerData.finishedQuests.Add(i);


                        UIManager.instance.questInfoCompleteButton.onClick.RemoveAllListeners();
                        UIManager.instance.questInfo.gameObject.SetActive(false);

                        
                    });
                }
                
                
                break;
            }
        }
    }
    




    void ReceiveCompletedQuest(Quest quest)
    {
        if (quest.reward.exp > 0) PlayerController.main.SetExperience(quest.reward.exp);
            if (quest.reward.items.Length > 0)
            {
                foreach(var item in quest.reward.items)
                {
                    print("You get : (" + item.amount + ")x" + ItemDataBase.items[item.id]);

                    //아이템 주기
                }
            }
    }
    public void ShowQuestInEvent()
    {
        ShowQuestInfo();

        if (!UIManager.instance.questInfoAcceptButton.gameObject.activeInHierarchy)
        {
            UIManager.instance.questInfoAcceptButton.gameObject.SetActive(true);
        }
        
    }


     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.main.contactPlayer = true;
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.main.contactPlayer = false;
        }
    }
   







}
