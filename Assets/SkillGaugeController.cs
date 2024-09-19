using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGaugeController : MonoBehaviour
{
    public Image skillGaugeImage;  // ゲージのImageコンポーネント
    public Button skillButton;     // 必殺技ボタンのButtonコンポーネント
    public GameObject skillPrefab; // 必殺技のプレハブ
    public Transform shootPoint;   // 発射位置（プレイヤーの位置）

    public float fillSpeed = 0.1f;  // ゲージの溜まるスピード
    public float maxGauge = 1f;     // ゲージの最大値（通常は1.0f）

    private float currentGauge = 0f; // 現在のゲージの値

    void Start()
    {
        // 必殺技ボタンにイベントリスナーを追加
        skillButton.onClick.AddListener(ActivateSkill);
    }

    void Update()
    {
        // ゲージを徐々に溜める
        if (currentGauge < maxGauge)
        {
            currentGauge += fillSpeed * Time.deltaTime;
            currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge); // ゲージの値を制限
            UpdateGaugeUI();
        }

        // スペースキーで必殺技を発動
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateSkill();
        }
    }

    private void UpdateGaugeUI()
    {
        // ゲージのUIを更新
        if (skillGaugeImage != null)
        {
            skillGaugeImage.fillAmount = currentGauge / maxGauge;
        }
    }

    private void ActivateSkill()
    {
        // ゲージが満タンであれば必殺技を発動
        if (currentGauge >= maxGauge)
        {
            Debug.Log("必殺技発動！");

            // 必殺技を発射
            ShootSkill();

            // ゲージをリセット
            currentGauge = 0f;
            UpdateGaugeUI();
        }
        else
        {
            Debug.Log("ゲージが不足しています！");
        }
    }

    private void ShootSkill()
    {
        if (skillPrefab != null && shootPoint != null)
        {
            // 必殺技のインスタンスを生成
            GameObject skill = Instantiate(skillPrefab, shootPoint.position, shootPoint.rotation);

            // 必殺技に力を加える
            Rigidbody2D rb = skill.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 必殺技の発射方向と力を設定
                Vector2 direction = shootPoint.up; // プレイヤーの上方向に発射
                float force = 10f; // 必殺技の発射力（調整可能）
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
    }
}
