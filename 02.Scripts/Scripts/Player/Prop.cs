﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamageable
{

    public void OnDamage(float damage)
    {
        Destroy(gameObject);

    }
}