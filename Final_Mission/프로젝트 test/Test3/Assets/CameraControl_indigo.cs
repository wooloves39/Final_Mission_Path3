﻿using UnityEngine;
using System.Collections;

public class CameraControl_indigo : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position;

#if UNITY_EDITOR || UNITY_STANDALONE
        //transform.rotation = player.rotation;
#endif
    }
}