using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2.0f;       // 敵キャラクターの移動速度
    public float minDistanceToMove = 2.0f; // 移動する距離の最小値
    public float maxDistanceToMove = 5.0f; // 移動する距離の最大値

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = true;

    void Start()
    {
        // 敵キャラクターの初期位置を保存
        startPosition = transform.position;

        // 移動する距離をランダムに決定
        float distanceToMove = Random.Range(minDistanceToMove, maxDistanceToMove);

        // 縦方向の目標位置を設定
        targetPosition = startPosition + new Vector3(0, distanceToMove, 0);
    }

    void Update()
    {
        if (isMoving)
        {
            // 敵キャラクターを目標位置に向かって移動させる
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // 目標位置に到達したかをチェック
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // 目標位置に到達したら移動を停止
                isMoving = false;
            }
        }
    }
}
