using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

    public GameObject effect; //검이 내는 빛

    void EffectOn()
    {
        effect.SetActive(true);
    }
    void EffectOff()
    {
        effect.SetActive(false);
    }
}
