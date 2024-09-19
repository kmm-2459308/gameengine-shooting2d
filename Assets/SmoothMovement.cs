using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed = 5.0f; // 移動速度
    public float smoothTime = 0.3f; // 滑らかさの時間

    private Vector3 targetPosition; // 目標位置
    private Vector3 velocity = Vector3.zero; // 速度

    void Update()
    {
        // 入力に基づいて目標位置を設定
        float moveX = Input.GetAxis("Horizontal"); // 左右の入力
        float moveY = Input.GetAxis("Vertical"); // 上下の入力

        // 移動ベクトルを計算
        Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;

        // 現在の位置を更新
        targetPosition = transform.position + move;

        // 目標位置に向かって滑らかに移動
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
