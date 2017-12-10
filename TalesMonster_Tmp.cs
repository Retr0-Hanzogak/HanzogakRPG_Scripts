using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalesMonster_Tmp : MonoBehaviour {

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();

        anim["walk"].wrapMode = WrapMode.Loop;

        SetAnimation("walk");
    }

    void SetAnimation(string aniName)
    {
        anim.CrossFade(aniName);
    }
}
