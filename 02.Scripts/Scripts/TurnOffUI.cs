using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOffUI : MonoBehaviour {
    
    public void OffUI()
    {
        if (transform.parent.gameObject.activeInHierarchy)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

	
}
