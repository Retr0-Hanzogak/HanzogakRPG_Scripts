using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour {

 public void LoadScene() //BedEnding 나왔을 때 처음으로 돌아감..
    {
        SceneManager.LoadScene(0);
    }
}
