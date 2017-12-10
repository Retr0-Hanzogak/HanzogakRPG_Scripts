using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    public static MoveManager instance;

    

     void Awake()
    {
        if (instance == null) instance = this;
    }

    public UserControl uc;
    public TigerMove tm;
    
    void MoveStop()
    {
        
        UserControl.playerMove = false;
        uc.h = 0;
        uc.v = 0;
        uc.animator.SetFloat("Speed", 0);
        uc.animator.Play("EquippedIdle", 0);

        
        tm.agent.enabled = false;

        tm.ani.SetBool("Run", false);

        tm.ani.Play("Idle", 0);
        

    }
    void MoveGo()
    {
        UserControl.playerMove = true;

        tm.agent.enabled = true;
    }

    


}
