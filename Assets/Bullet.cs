using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // 弾の速度
    public float randomDirectionOffset = 0.5f; // ランダムな方向のオフセット

    private Vector2 direction; // 弾の移動方向

    void Start()
    {
        // ランダムな方向を生成
        float randomX = Random.Range(-randomDirectionOffset, randomDirectionOffset);
        float randomY = Random.Range(-1f, -0.5f); // Y方向は下向きに限定
        direction = new Vector2(randomX, randomY).normalized; // 正規化して方向を設定
    }

    void Update()
    {
        // 弾を指定された方向に移動
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // 画面外に出たら削除
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
        {
            Destroy(gameObject);
        }
    }
}
