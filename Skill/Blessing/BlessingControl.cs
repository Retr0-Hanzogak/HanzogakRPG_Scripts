using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingControl : MonoBehaviour {

    int level;
    float increaseDamageRate;
    float normalDamagePlus;
    float heavyDamagePlus;
    int skillNum = 8;

    private void Start()
    {
        level = SkillData.instance.skillData[skillNum].level;

        increaseDamageRate = SkillData.instance.skillData[skillNum].firstDamage * Mathf.Pow(SkillData.instance.skillData[skillNum].increaseDamageRatePerLevel, SkillData.instance.skillData[skillNum].level - 1);

        normalDamagePlus = PlayerAttack.instance.normalDamage;
        heavyDamagePlus = PlayerAttack.instance.heavyDamage;

        normalDamagePlus *= increaseDamageRate;
        heavyDamagePlus *= increaseDamageRate;
        StartCoroutine(BlessingTime());
    }

    IEnumerator BlessingTime()
    {
        PlayerAttack.instance.normalDamage += normalDamagePlus;
        PlayerAttack.instance.heavyDamage += heavyDamagePlus;
        yield return new WaitForSeconds(20 + level * 5);
        PlayerAttack.instance.normalDamage -= normalDamagePlus;
        PlayerAttack.instance.heavyDamage -= heavyDamagePlus;
        Destroy(gameObject);
    }
}
