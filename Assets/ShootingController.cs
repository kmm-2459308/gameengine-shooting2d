using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject energyPrefab;  // 発射する弾のプレハブ
    public Transform firePoint;       // 弾が発射される位置
    public float fireRate = 1f;       // 弾を発射する間隔（秒）

    private void Start()
    {
        // 指定された間隔で弾を発射する
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    private void FireBullet()
    {
        if (energyPrefab != null && firePoint != null)
        {
            // 弾を発射する
            Instantiate(energyPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned.");
        }
    }
}
