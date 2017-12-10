using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;
public class Prolog7 : MonoBehaviour {

    public Flowchart dialog;

    public PlayableDirector timeline;

    

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void TransToNext() //프롤로그 7로 넘어가기 위해 Complete를 하면 다음 이벤트로 넘어가기 위한 함수
    {
        UIManager.instance.questInfoCompleteButton.onClick.AddListener(() => {

            SetStartPos.instance.EventStartPos(character, characterPos);

            dialog.ExecuteBlock("Prolog7");


        });
    }
    void EventOn()
    {
        timeline.Play();
    }
    void LookAtPlayer()
    {
        for (int i = 0; i < 10; i++)
        {
            character[i].transform.LookAt(characterPos[10]);
        }
    }
    void Die()
    {
        for (int i = 0; i < 10; i++)
        {
            character[i].GetComponent<Animator>().SetTrigger("Dead");
        }
    }
   
}