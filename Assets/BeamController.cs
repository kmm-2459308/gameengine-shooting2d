using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject BeamPrefab;  // 発射する弾のプレハブ
    public Transform firePoint;       // 弾が発射される位置
    public float fireRate = 1f;       // 弾を発射する間隔（秒）

    private bool canFire = true;      // 発射可能かどうかを示すフラグ

    private void Update()
    {
        // スペースボタンが押された時に弾を発射
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            FireBullet();
            // 発射間隔を設定する
            StartCoroutine(FireRateCooldown());
        }
    }

    private void FireBullet()
    {
        if (BeamPrefab != null && firePoint != null)
        {
            // 弾を発射する
            Instantiate(BeamPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned.");
        }
    }

    private IEnumerator FireRateCooldown()
    {
        canFire = false;               // 発射不可にする
        yield return new WaitForSeconds(fireRate); // 指定した時間待機
        canFire = true;                // 発射可能にする
    }
}