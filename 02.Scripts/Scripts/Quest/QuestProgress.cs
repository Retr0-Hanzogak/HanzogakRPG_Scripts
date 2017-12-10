using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestProgress : MonoBehaviour {

    public static QuestProgress instance;

    public int progress = 0;

    public bool goToHouse; // prolog5_0에서 집에 들어갈지 말지 정하는 변수
    private void Awake()
    {
        if (instance == null) instance = this;
        
    }
}
