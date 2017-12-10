using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEQ : MonoBehaviour {

    public Reward reward;
	// Use this for initialization
	void Start () {

        reward = GetComponent<Reward>();

        FirsEquipment();
        Temp();

    }
    void FirsEquipment()
    {
        reward.ForceEquipment();
    }
    void Temp() // 무기 바뀌는지 실험용
    {
        reward.RewardItem();
    }
	
	
}
