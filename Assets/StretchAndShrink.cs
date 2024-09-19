using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchAndShrink : MonoBehaviour
{
    // Start is called before the first frame update
    public float stretchSpeed = 1.0f;            // 縦に伸びる速度
    public float shrinkSpeed = 1.0f;             // 横幅が狭くなる速度
    public float minWidth = 0.1f;                // 横幅の最小値
    public float destroyThreshold = 0.1f;        // 消えるまでのスケールの最小値
    public float damageAmount = 10.0f;           // ダメージ量
    public float damageAreaHorizontalMultiplier = 1.5f; // ダメージエリアの横幅の拡張倍率
    public float damageAreaVerticalMultiplier = 2.0f;   // ダメージエリアの縦幅の拡張倍率

    private Vector3 originalScale;               // 初期スケール
    private Rect damageArea;                     // ダメージエリア

    void Start()
    {
        // 初期スケールを保存
        originalScale = transform.localScale;

        // ダメージエリアを初期化
        UpdateDamageArea();
    }

    void Update()
    {
        // 現在のスケールを取得
        Vector3 currentScale = transform.localScale;

        // 縦方向にスケールを増加させる
        currentScale.y += stretchSpeed * Time.deltaTime;

        // 横幅を狭くする
        currentScale.x -= shrinkSpeed * Time.deltaTime;

        // 横幅が最小値以下にならないように制限
        if (currentScale.x < minWidth)
        {
            currentScale.x = minWidth;
        }

        // オブジェクトのスケールを更新
        transform.localScale = currentScale;

        // ダメージエリアを更新
        UpdateDamageArea();

        // スケールが一定以下になったらオブジェクトを削除する
        if (currentScale.x <= destroyThreshold || currentScale.y <= destroyThreshold)
        {
            Destroy(gameObject); // オブジェクトを削除
        }

        // ダメージエリア内の「Enemy」タグのオブジェクトにダメージを与える
        ApplyDamage();
    }

    void UpdateDamageArea()
    {
        // オブジェクトのサイズに基づいてダメージエリアを更新
        Vector2 position = (Vector2)transform.position;
        Vector2 size = transform.localScale;

        // 横幅と縦幅の拡張倍率を設定
        Vector2 damageAreaSize = new Vector2(size.x * damageAreaHorizontalMultiplier, size.y * damageAreaVerticalMultiplier);
        damageArea = new Rect(position - damageAreaSize / 2, damageAreaSize);
    }

    void ApplyDamage()
    {
        // ダメージエリア内の全てのターゲットを取得
        Collider2D[] targets = Physics2D.OverlapAreaAll(damageArea.min, damageArea.max);

        foreach (var target in targets)
        {
            // タグが「Enemy」のオブジェクトのみを対象にダメージを与える
            if (target.CompareTag("Enemy"))
            {
                EnemyHealth health = target.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    health.TakeDamage((int)damageAmount);
                }
            }

            if (target.CompareTag("BOSS"))
            {
                BOSSHealth health = target.GetComponent<BOSSHealth>();
                if (health != null)
                {
                    health.TakeDamage((int)damageAmount);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // エディタ内でダメージエリアを描画するための設定
        Gizmos.color = Color.red; // 色を赤に設定
        Vector2 position = (Vector2)transform.position;
        Vector2 size = transform.localScale;
        Vector2 damageAreaSize = new Vector2(size.x * damageAreaHorizontalMultiplier, size.y * damageAreaVerticalMultiplier);
        Rect areaRect = new Rect(position - damageAreaSize / 2, damageAreaSize);

        // ダメージエリアの四隅を描画
        Gizmos.DrawWireCube(areaRect.center, areaRect.size);
    }
}
