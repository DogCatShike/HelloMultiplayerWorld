using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTest : NetworkBehaviour
{
    void Update()
    {
        if (IsServer)
        {
            float theta = Time.time;
            // 公式没看明白
            transform.position = new Vector3((float)Math.Cos(theta), 0.0f, (float)Math.Sin(theta));
        }
    }
}