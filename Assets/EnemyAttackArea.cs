using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public float attackRadius = 5f; // 攻撃範囲の半径
    public int damageAmount = 10; // 攻撃のダメージ量
    public float damageInterval = 1f; // ダメージを与える間隔（秒）

    private void Update()
    {
        // プレイヤーにダメージを与える処理を毎フレームチェック
        DealDamageToPlayersInRange();
    }

    private void DealDamageToPlayersInRange()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }
                Destroy(gameObject); // この行を削除することで、敵が自分で破壊されないようにする
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Gizmosを使って攻撃範囲を可視化
        Gizmos.color = Color.red; // 攻撃範囲の色
        Gizmos.DrawWireSphere(transform.position, attackRadius); // 範囲を描画
    }
}
