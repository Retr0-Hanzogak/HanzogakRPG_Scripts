using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPos : MonoBehaviour {

    public static SetStartPos instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void EventStartPos(List<GameObject>gameobj, List<Transform> gameobjPos)
    {
        for(int i =0; i < gameobj.Count; i++)
        {
            gameobj[i].transform.position = gameobjPos[i].position;
            gameobj[i].transform.rotation = gameobjPos[i].rotation;
            
        }
    }
   
    
        
    
}
