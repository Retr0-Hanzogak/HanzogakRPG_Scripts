using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArrow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(TurnOnOff());
    }

    IEnumerator TurnOnOff()
    {

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

}
