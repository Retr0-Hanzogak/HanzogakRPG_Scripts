using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;
    public Animator fadeImageAni;

    public Animator fadeWhiteImageAni;

    public Image black;

    private void Awake()
    {
        if (instance == null) instance = this;

        
    }

   void FadeInout()
    {
        fadeImageAni.SetTrigger("Fade");
    }
   void FadeWhite()
    {
        fadeWhiteImageAni.SetTrigger("FadeWhite");
    }
    
   

}
