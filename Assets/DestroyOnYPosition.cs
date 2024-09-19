using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnYPosition : MonoBehaviour
{
    public float yThreshold = 20f;  // Y軸の位置の閾値

    void Update()
    {
        // オブジェクトのY軸の位置をチェック
        if (transform.position.y > yThreshold)
        {
            // オブジェクトを削除
            Destroy(gameObject);
        }
    }
}
