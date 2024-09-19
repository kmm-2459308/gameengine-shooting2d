using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyenergyPrefab;  // ���˂���e�̃v���n�u
    public Transform firePoint;       // �e�����˂����ʒu
    public float fireRate = 1f;       // �e�𔭎˂���Ԋu�i�b�j

    private void Start()
    {
        // �w�肳�ꂽ�Ԋu�Œe�𔭎˂���
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    private void FireBullet()
    {
        if (enemyenergyPrefab != null && firePoint != null)
        {
            // �e�𔭎˂���
            Instantiate(enemyenergyPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned.");
        }
    }
}
