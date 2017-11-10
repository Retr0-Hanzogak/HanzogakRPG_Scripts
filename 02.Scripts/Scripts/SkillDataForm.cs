using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillDataForm
{

    public GameObject prefab;
    public int level;
    public float coolTime;
    public float playTime;
    public float firstDamage;
    public float increaseDamageRatePerLevel;
    public List<int> precedenceSkill;
}
