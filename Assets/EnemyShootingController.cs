using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyenergyPrefab;  // ”­Ë‚·‚é’e‚ÌƒvƒŒƒnƒu
    public Transform firePoint;       // ’e‚ª”­Ë‚³‚ê‚éˆÊ’u
    public float fireRate = 1f;       // ’e‚ğ”­Ë‚·‚éŠÔŠui•bj

    private void Start()
    {
        // w’è‚³‚ê‚½ŠÔŠu‚Å’e‚ğ”­Ë‚·‚é
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    private void FireBullet()
    {
        if (enemyenergyPrefab != null && firePoint != null)
        {
            // ’e‚ğ”­Ë‚·‚é
            Instantiate(enemyenergyPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned.");
        }
    }
}
