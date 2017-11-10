using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{

    public static SkillData instance;

    public SkillDataForm[] skillData;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

}
