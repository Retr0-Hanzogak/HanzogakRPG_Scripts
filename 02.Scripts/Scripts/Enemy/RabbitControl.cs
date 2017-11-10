using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitControl : MonoBehaviour {

    public static bool rabbitMove = false; //프롤로그에서 토끼의 움직임을 관리하기위한 bool

    


    public void CanMove()
    {
        rabbitMove = true;
    }
    public void CanNotMove()
    {
        rabbitMove = false;
    }




}
