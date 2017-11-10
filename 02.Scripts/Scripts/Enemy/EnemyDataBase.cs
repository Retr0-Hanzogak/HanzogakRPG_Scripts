using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataBase : MonoBehaviour {

    public static Dictionary<int, string> monsters = new Dictionary<int, string>()
    {
        {0,"Rabbit" },
        {27,"Zombie"},
        {99,"Ghost"}
    };
}
