using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHotKeyPopUp : MonoBehaviour {

    public GameObject[] hotKeyButton = new GameObject[10];

    private void OnEnable()
    {
        for(int i = 0; i < 10; i++)
        {
            if(SkillData.instance.skillData[i].level > 0)
            {
                hotKeyButton[i].SetActive(true);
            }
        }
    }
}
