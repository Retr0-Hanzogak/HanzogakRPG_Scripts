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
    
    
    void MoveStop()
    {
        
        UserControl.playerMove = false;
        uc.h = 0;
        uc.v = 0;
        uc.animator.SetFloat("Speed", 0);
        uc.animator.Play("EquippedIdle", 0);

        

    }
    void MoveGo()
    {
        UserControl.playerMove = true;
        
    }

    


}
