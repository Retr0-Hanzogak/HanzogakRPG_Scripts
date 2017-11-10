using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog4_2 : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    void SetPos()
    {
        SetStartPos.instance.EventStartPos(character, characterPos);
        
    }
}
