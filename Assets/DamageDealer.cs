using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;  // 弾が与えるダメージ量
    public float detectionRadius = 1f;  // 敵を検出する半径
    public float lifeTime = 5f;  // 弾の寿命

    private void Start()
    {
        // 指定した時間後に弾を自動で削除
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // 弾の位置を中心に指定した半径内の敵を検出する
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D hit in hits)
        {
            // 他のオブジェクトのタグが "Enemy" であれば、ダメージを与える
            if (hit.CompareTag("Enemy"))
            {
                // EnemyHealth コンポーネントを取得
                EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

                // EnemyHealth コンポーネントが存在すればダメージを与える
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }

                // 弾のオブジェクトを削除する
                Destroy(gameObject);
                break;  // 一度当たったら処理を終える
            }

            if (hit.CompareTag("BOSS"))
            {
                // EnemyHealth コンポーネントを取得
                BOSSHealth bossHealth = hit.GetComponent<BOSSHealth>();

                // EnemyHealth コンポーネントが存在すればダメージを与える
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(damageAmount);
                }

                // 弾のオブジェクトを削除する
                Destroy(gameObject);
                break;  // 一度当たったら処理を終える
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Sceneビューで検出範囲を表示する
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
