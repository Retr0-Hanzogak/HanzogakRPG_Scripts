using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreePopUp : MonoBehaviour {

    public GameObject[] m_PopUpObjects;

    private void OnEnable()
    {
        foreach(GameObject obj in m_PopUpObjects)
        {
            obj.SetActive(true);
        }
    }
}
