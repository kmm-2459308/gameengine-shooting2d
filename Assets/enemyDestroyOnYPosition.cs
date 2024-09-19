using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyOnYPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public float yThreshold = -20f;  // Y軸の位置の閾値

    void Update()
    {
        // オブジェクトのY軸の位置をチェック
        if (transform.position.y < yThreshold)
        {
            // オブジェクトを削除
            Destroy(gameObject);
        }
    }
}
