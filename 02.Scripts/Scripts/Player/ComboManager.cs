using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour {

    public static ComboManager instance;

    public int playerCombo = 0;

    public bool doingCombo = false;

    public static float attacktime = 0f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void start()
    {
        playerCombo = 0;

        
    }
    public void ComboPlus()
    {
        StartCoroutine(Combo());
    }

    public IEnumerator Combo()
    {
        

            if (doingCombo)
            {

                attacktime = 0f;

                if (!UIManager.instance.playerCombo.gameObject.activeInHierarchy)
                {
                    UIManager.instance.playerCombo.gameObject.SetActive(true);
                }

                yield return new WaitForSeconds(3f);

                if (!doingCombo)
                {
                    UIManager.instance.playerCombo.gameObject.SetActive(false);
                }
            }
        
           
        
        
    }
    public void ComboReset()
    {
        if (PlayerController.main.isHit)
        {
            playerCombo = 0;
            UIManager.instance.playerCombo.gameObject.SetActive(false);
        }
        if (attacktime > 2f)
        {
            playerCombo = 0;
            UIManager.instance.playerCombo.gameObject.SetActive(false);
        }

    }
    void GetAttackTime()
    { 

        attacktime += Time.deltaTime;

    }

    void Update()
    {
        ComboReset();

        GetAttackTime();

        UIManager.instance.playerCombo.text = "<color=#ff0000>" + playerCombo.ToString() + "</color>"  + "HIT";
    }
}
