using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;

public class Prolog2_2 : MonoBehaviour
{

    PlayableDirector timeline;

    public List<GameObject> character = new List<GameObject>();
    public List<Transform> characterPos = new List<Transform>();

   
    public Transform tplayer2;
    public GameObject player;

    public Transform tigerPos;
    public GameObject tiger;

    public Reward reward;


    public Flowchart dialog;




    void Start()
    {
        reward = GetComponent<Reward>();
        timeline = GetComponent<PlayableDirector>();

    }
    void TransToNext() //프롤로그 2_2로 넘어가기 위해 Complete를 하면 다음 이벤트로 넘어가기 위한 함수
    {
        UIManager.instance.questInfoCompleteButton.onClick.AddListener(() => {

            dialog.ExecuteBlock("Prolog2_2");

            Invoke("EventOn", 1f);

            Debug.Log("ok");

            SetStartPos.instance.EventStartPos(character, characterPos);

            reward.RewardItem();



        });
    }
    void EventOn()
    {
        timeline.Play();
        

    }
    void PlayerMoveInEvent()
    {

        player.transform.position = tplayer2.position;
        player.transform.rotation = tplayer2.rotation;


    }
    void TigerMoveInEvnet()
    {
        tiger.transform.position = tigerPos.position;
        tiger.transform.rotation = tigerPos.rotation;
    }
   




}



