using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 敵の最大体力
    public int maxHealth = 30;
    // 現在の体力
    private int currentHealth;

    // 撃破エフェクトのPrefab
    public GameObject destroyEffect;

    // 開始時に呼ばれる
    void Start()
    {
        // 現在の体力を最大体力で初期化
        currentHealth = maxHealth;
    }

    // ダメージを受けたときに呼び出す
    public void TakeDamage(int damage)
    {
        // 現在の体力を減少させる
        currentHealth -= damage;

        // 体力が0以下になった場合の処理
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 敵が死亡したときの処理
    void Die()
    {
        // 撃破エフェクトを生成
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        // 敵のオブジェクトを削除
        Destroy(gameObject);
    }
}
