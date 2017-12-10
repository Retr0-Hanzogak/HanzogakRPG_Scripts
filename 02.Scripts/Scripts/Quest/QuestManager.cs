using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public Dictionary<int, Quest> questDictionary = new Dictionary<int, Quest>();

  

    void Awake()
    {
        if (instance == null)
            instance = this;
        

    }
    public void LoadQuest(int id)
    {
        Quest newQuest = JsonUtility.FromJson<Quest>(Resources.Load<TextAsset>("JsonFiles/" + id.ToString("00")).text);

        questDictionary.Add(newQuest.id, newQuest);    

    }
  
    public void ShowQuestInfo(Quest quest)
    {

        UIManager.instance.questInfo.gameObject.SetActive(true);

        UIManager.instance.questInfoCompleteButton.gameObject.SetActive(false);

        UIManager.instance.questInfoCancelButton.gameObject.SetActive(true);

        UIManager.instance.questInfoAcceptButton.onClick.RemoveAllListeners();

        UIManager.instance.questInfoAcceptButton.onClick.AddListener(() =>{

            PlayerData.AddQuest(quest.id);
            UIManager.instance.questInfoAcceptButton.gameObject.SetActive(false);
            UIManager.instance.questInfo.gameObject.SetActive(false);
            ShowActiveQuests();
            UIManager.instance.questAlarm.gameObject.SetActive(true);

            TigerNpcController.doingQuest = true;


        });


        UIManager.instance.questInfoContent.Find("Name").GetComponent<Text>().text = quest.questName;
        UIManager.instance.questInfoContent.Find("Description").GetComponent<Text>().text = quest.description;

        //Task
        string taskString = "Task:\n";

        if(quest.task.kills != null)
        {
            foreach(Quest.QuestKill qk in quest.task.kills)
            {
                int currentKills = 0;

                if (PlayerData.monsterKilled.ContainsKey(qk.id)&& PlayerData.activeQuests.ContainsKey(quest.id))
                
                    currentKills = PlayerData.monsterKilled[qk.id].amount - PlayerData.activeQuests[quest.id].kills[qk.id].initialAmount;

                
                taskString += "Slay " + (currentKills) + "/" + qk.amount + " " + EnemyDataBase.monsters[qk.id] + ".\n";
            }
        }

        if(quest.task.items != null)
        {
            foreach(Quest.QuestItem qi in quest.task.items)
            {
                taskString += "Bring" + qi.amount + "" + ItemDataBase.items[qi.id] + ".\n";
            }
        }
        if(quest.task.talkTo != null)
        {
            foreach(int id in quest.task.talkTo)
            {
                taskString += "Talk To" + NpcDataBase.npcs[id] + ".\n";
            }
        }
        if(quest.task.locations != null)
        {
            foreach(Quest.QuestLocation ql in quest.task.locations)
            {
                int currentLocation = 0;

                if (PlayerData.getDestination.ContainsKey(ql.id) && PlayerData.activeQuests.ContainsKey(quest.id))

                    currentLocation = PlayerData.getDestination[ql.id].amount - PlayerData.activeQuests[quest.id].locations[ql.id].initialAmount;

                taskString += "Go to destination" + (currentLocation) + "/" + ql.amount + ".\n";
            }
        }
        if(quest.task.contacts != null)
        {
            foreach(Quest.QuestContact qc in quest.task.contacts)
            {
                int currentContact = 0;

                if (PlayerData.npcContacted.ContainsKey(qc.id) && PlayerData.activeQuests.ContainsKey(quest.id))

                    currentContact = PlayerData.npcContacted[qc.id].amount - PlayerData.activeQuests[quest.id].contacts[qc.id].initialAmount;

                taskString += "Meet the Npc" + (currentContact) + "/" + qc.amount + "\n";
            }
        }
        UIManager.instance.questInfoContent.Find("Task").GetComponent<Text>().text = taskString;
       
        //Reward
        string rewardString = "Reward: \n";

        if (quest.reward.items != null)
        {
            foreach(Quest.QuestItem qi in quest.reward.items)
            {
                rewardString += qi.amount + "" + ItemDataBase.items[qi.id] + ".\n";
            }
        }
        if (quest.reward.exp > 0) rewardString += quest.reward.exp + "Experience.\n";
        if (quest.reward.money > 0) rewardString += quest.reward.money + "Money.\n";
        UIManager.instance.questInfoContent.Find("Reward").GetComponent<Text>().text = rewardString;
    }
    public bool IsQuestAvailable(int questId, PlayerController player)
    {
        return (questDictionary[questId].requiredLevel <= player.level);
    }
    

    public void ShowActiveQuests()
    {
        foreach(PlayerData.ActiveQuest activeQuest in PlayerData.activeQuests.Values)

        {
            int i = activeQuest.id;

            if (UIManager.instance.QuestBookContent.Find(i.ToString()) != null)
            {
                continue;
            }

            GameObject questListButton = Instantiate(Resources.Load("Prefabs/listButton") as GameObject);
            questListButton.name = questDictionary[i].id.ToString();
            questListButton.transform.SetParent(UIManager.instance.QuestBookContent);
            questListButton.transform.localScale = Vector3.one;
            questListButton.transform.Find("Text").GetComponent<Text>().text = questDictionary[i].questName;
            
            int questId = new int();
            questId = i;
            questListButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowQuestInfo(questDictionary[questId]);
            });

            
        }
        
    }
    public bool IsQuestFinished(int questId){
    
        Quest quest = questDictionary[questId];


        if(quest.task.kills.Length > 0)
        {
        
            foreach(var questKill in quest.task.kills){
            
                if (!PlayerData.monsterKilled.ContainsKey(questKill.id) || !PlayerData.activeQuests.ContainsKey(quest.id))
                {
                
                    return false;
                }
                int currentKills = PlayerData.monsterKilled[questKill.id].amount - PlayerData.activeQuests[quest.id].kills[questKill.id].initialAmount;
                
                if (currentKills < questKill.amount) {
               
                    return false;
                }
            }
        }
        
        
        if(quest.task.contacts.Length > 0)
        {
            foreach(var questContact in quest.task.contacts)
            {
                if(!PlayerData.npcContacted.ContainsKey(questContact.id) || !PlayerData.activeQuests.ContainsKey(quest.id))
                {
                    return false;
                }
                int currentContact = PlayerData.npcContacted[questContact.id].amount - PlayerData.activeQuests[quest.id].contacts[questContact.id].initialAmount;

                if(currentContact < questContact.amount)
                {
                    return false;
                }
            }
        }
        if(quest.task.locations.Length >0)
        {
            foreach (var questLocation in quest.task.locations)
            {
                if (!PlayerData.getDestination.ContainsKey(questLocation.id) || !PlayerData.activeQuests.ContainsKey(quest.id))
                {
                    return false;
                }
                int currentLocation = PlayerData.getDestination[questLocation.id].amount - PlayerData.activeQuests[quest.id].locations[questLocation.id].initialAmount;

                if(currentLocation < questLocation.amount)
                {
                    return false;
                }
            }
        }
        if (quest.task.items.Length > 0)
        {
            foreach(var questItem in quest.task.items)
            {
                if(!PlayerData.playerItem.ContainsKey(questItem.id) || !PlayerData.activeQuests.ContainsKey(quest.id))
                {
                    return false;
                }

                int currentItem = PlayerData.playerItem[questItem.id].amount;

                if(currentItem < questItem.amount)
                {
                    return false;
                }
            }
        }

        return true;

        
    }
 
    
        
   


}
