using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestProgress : MonoBehaviour {

    public static QuestProgress instance;

    public int progress = 0;


    private void Awake()
    {
        if (instance == null) instance = this;
        
    }
}
