using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // 攻撃のダメージ量

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーに衝突した場合
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーのHealthスクリプトを取得してダメージを与える
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
