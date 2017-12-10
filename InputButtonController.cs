using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputButtonController : MonoBehaviour {

    private GameObject player;

    public GameObject skillBook_HotKey;
    public Sprite[] skillIcon = new Sprite[10];
    public Image[] hotKeyImage = new Image[4];

    int currentHotKeyCount;
    int[] inputHotKeyNum = new int[4];

    private void Start()
    {
        player = GameObject.Find("Player");
        ResetHoyKeyCount();
    }

    public void ResetHoyKeyCount()
    {
        currentHotKeyCount = 0;
        for (int i = 0; i < 4; i++)
        {
            inputHotKeyNum[i] = -1;
            hotKeyImage[i].sprite = null;
            hotKeyImage[i].enabled = false;
        }
    }

    public void SetHotKeyNum(int num)
    {
        inputHotKeyNum[currentHotKeyCount] = num;

        hotKeyImage[currentHotKeyCount].enabled = true;
        hotKeyImage[currentHotKeyCount].sprite = skillIcon[num];
        currentHotKeyCount++;
        if(currentHotKeyCount > 3)
        {
            skillBook_HotKey.SetActive(false);
        }
    }

    public void CallSkill(int num)
    {
        if(inputHotKeyNum[num] == -1)
        {
            return;
        }
        player.SendMessage("GetSkillInput", inputHotKeyNum[num], SendMessageOptions.DontRequireReceiver);
    }
}
