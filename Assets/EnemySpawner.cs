using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1Prefab;         // 敵キャラクターのプレハブ
    public float spawnInterval = 2.0f;     // 敵が出現する間隔（秒）
    public float minXPosition = -5.0f;     // 敵の出現位置の最小Y座標
    public float maxXPosition = 5.0f;      // 敵の出現位置の最大Y座標
    public float spawnYPosition = 10.0f;   // 敵が出現するX座標（画面外）

    private void Start()
    {
        // 敵を定期的に出現させるためのコルーチンを開始
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // 敵の出現位置をランダムに決定
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0);

        // 敵キャラクターを指定した位置に出現させる
        GameObject enemy = Instantiate(enemy1Prefab, spawnPosition, Quaternion.identity);

        enemy.transform.Rotate(180, 0, 0);
    }

}
