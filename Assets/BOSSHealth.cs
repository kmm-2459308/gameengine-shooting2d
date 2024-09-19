using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSHealth : MonoBehaviour
{
    public int maxHealth = 30; // 敵の最大体力
    private int currentHealth; // 現在の体力

    // UIイメージの参照
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth; // 初期体力を最大体力で設定
        UpdateHealthBar(); // 初期状態のバーを更新
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ダメージを受ける
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 体力が負にならないように

        UpdateHealthBar(); // ダメージを受けた後にバーを更新

        if (currentHealth <= 0)
        {
            Die(); // 体力が0になったら死亡処理
        }
    }

    void Die()
    {
        Destroy(gameObject); // 敵のオブジェクトを削除
    }

    // 体力バーの値を更新するメソッド
    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth; // 現在の体力を割合で設定
    }
}
