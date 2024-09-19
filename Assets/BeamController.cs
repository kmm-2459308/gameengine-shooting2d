using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject BeamPrefab;  // ���˂���e�̃v���n�u
    public Transform firePoint;       // �e�����˂����ʒu
    public float fireRate = 1f;       // �e�𔭎˂���Ԋu�i�b�j

    private bool canFire = true;      // ���ˉ\���ǂ����������t���O

    private void Update()
    {
        // �X�y�[�X�{�^���������ꂽ���ɒe�𔭎�
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            FireBullet();
            // ���ˊԊu��ݒ肷��
            StartCoroutine(FireRateCooldown());
        }
    }

    private void FireBullet()
    {
        if (BeamPrefab != null && firePoint != null)
        {
            // �e�𔭎˂���
            Instantiate(BeamPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned.");
        }
    }

    private IEnumerator FireRateCooldown()
    {
        canFire = false;               // ���˕s�ɂ���
        yield return new WaitForSeconds(fireRate); // �w�肵�����ԑҋ@
        canFire = true;                // ���ˉ\�ɂ���
    }
}