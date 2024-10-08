using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 45f; // 回転速度（度/秒）

    void Update()
    {
        // 回転のための角度を計算
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // 回転を適用
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
