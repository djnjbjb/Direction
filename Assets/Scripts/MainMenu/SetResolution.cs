﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(800, 800, false);
    }
}
