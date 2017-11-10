using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDataBase : MonoBehaviour {

    public static Dictionary<int, string> npcs = new Dictionary<int, string>()
    {
        {0,"Witch Doctor" },
        {1,"Nurse"},
        {2,"Mayor"}
    };
}
