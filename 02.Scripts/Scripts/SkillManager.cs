using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public static SkillManager instance;

    Transform player;

    private int sp = 0;
    private bool[] skillCoolTime = new bool[10];

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        for (int i = 0; i < 10; i++)
            skillCoolTime[i] = true;
    }

    public void AddSP()
    {
        sp++;
        UpdateUI_SP();
    }

    public void AddSkillLv(int skillNum)
    {
        if(sp <= 0 || SkillData.instance.skillData[skillNum].level >= 10)
        {
            return;
        }

        for(int i = 0; i < SkillData.instance.skillData[skillNum].precedenceSkill.Count; i++)
        {
            if (SkillData.instance.skillData[SkillData.instance.skillData[skillNum].precedenceSkill[i]].level <= 0)
                return;
        }

        sp--;
        UpdateUI_SP();

        string lvUI = UIManager.instance.skillLv_UI[skillNum].text;
        SkillData.instance.skillData[skillNum].level++;
        lvUI = SkillData.instance.skillData[skillNum].level.ToString();

        UIManager.instance.skillLv_UI[skillNum].text = lvUI;
        
    }

    IEnumerator CoolTimeCheck(int skillNum)
    {
        skillCoolTime[skillNum] = false;
        Activate(skillNum);
        yield return new WaitForSeconds(SkillData.instance.skillData[skillNum].coolTime);
        skillCoolTime[skillNum] = true;

    }

    public void SkillSet(int skillNum)
    {
        if (SkillData.instance.skillData[skillNum].level > 0 && skillCoolTime[skillNum])
        {
            StartCoroutine(CoolTimeCheck(skillNum));
        }
    }

    void Activate(int skillNum)
    {
        GameObject instanceSkill = Instantiate(SkillData.instance.skillData[skillNum].prefab,player.position,player.rotation);

        instanceSkill.transform.parent = player;

        Destroy(instanceSkill, SkillData.instance.skillData[skillNum].playTime);
    }

    void UpdateUI_SP()
    {
        UIManager.instance.sp_UI.text = "SP : " + sp;
    }
}
