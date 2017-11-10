using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerData
{

    public static Dictionary<int, ActiveQuest> activeQuests = new Dictionary<int, ActiveQuest>();

    public static List<int> finishedQuests = new List<int>();

    public static Dictionary<int, MonsterKills> monsterKilled = new Dictionary<int, MonsterKills>();

    public static Dictionary<int, NpcContact> npcContacted = new Dictionary<int, NpcContact>();

    public static Dictionary<int, Destination> getDestination = new Dictionary<int, Destination>();

    public static Dictionary<int, Item> playerItem = new Dictionary<int, Item>();

    public static void AddQuest(int id)
    {
        if (activeQuests.ContainsKey(id)) return;

        Quest quest = QuestManager.instance.questDictionary[id];
        ActiveQuest newActiveQuests = new ActiveQuest();
        newActiveQuests.id = id;
        newActiveQuests.dateTaken = DateTime.Now.ToLongDateString();

        if (quest.task.kills.Length > 0)
        {
            newActiveQuests.kills = new Quest.QuestKill[quest.task.kills.Length];

            foreach (Quest.QuestKill questKill in quest.task.kills)
            {
                newActiveQuests.kills[questKill.id] = new Quest.QuestKill();

                if (!monsterKilled.ContainsKey(questKill.id)) monsterKilled.Add(questKill.id, new PlayerData.MonsterKills());

                newActiveQuests.kills[questKill.id].initialAmount = monsterKilled[questKill.id].amount;
            }
        }
        
        if (quest.task.contacts.Length > 0)
        {
            newActiveQuests.contacts = new Quest.QuestContact[quest.task.contacts.Length];

            foreach(Quest.QuestContact questContact in quest.task.contacts)
            {
                newActiveQuests.contacts[questContact.id] = new Quest.QuestContact();

                if (!npcContacted.ContainsKey(questContact.id)) npcContacted.Add(questContact.id, new PlayerData.NpcContact());

                newActiveQuests.contacts[questContact.id].initialAmount = npcContacted[questContact.id].amount;

                
            }
        }
        
        if (quest.task.locations.Length > 0)
        {
            newActiveQuests.locations = new Quest.QuestLocation[quest.task.locations.Length];

            foreach (Quest.QuestLocation questLocation in quest.task.locations)
            {
                newActiveQuests.locations[questLocation.id] = new Quest.QuestLocation();

                if (!getDestination.ContainsKey(questLocation.id)) getDestination.Add(questLocation.id, new PlayerData.Destination());

                newActiveQuests.locations[questLocation.id].initialAmount = getDestination[questLocation.id].amount;
            }
            

            
        }
        if(quest.task.items.Length > 0)
        {
            newActiveQuests.items = new Quest.QuestItem[quest.task.items.Length];

            foreach(Quest.QuestItem questItem in quest.task.items)
            {
                newActiveQuests.items[questItem.id] = new Quest.QuestItem();

                if (!playerItem.ContainsKey(questItem.id)) playerItem.Add(questItem.id, new PlayerData.Item());

                newActiveQuests.items[questItem.id].initialAmount = playerItem[questItem.id].amount;
            }
        }
        
        activeQuests.Add(id, newActiveQuests);

    }

    public class MonsterKills
    {
        public int id;
        public int amount;

    }
    public class ActiveQuest
    {
        public int id;
        public string dateTaken;
        public Quest.QuestKill[] kills;
        public Quest.QuestContact[] contacts;
        public Quest.QuestLocation[] locations;
        public Quest.QuestItem[] items;
    }
    public class NpcContact
    {
        public int id;
        public int amount;
    }
    public class Destination
    {
        public int id;
        public int amount;
    }
    public class Item
    {
        public int id;
        public int amount;
    }
}