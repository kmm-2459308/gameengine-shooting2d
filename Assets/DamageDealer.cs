using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;  // �e���^����_���[�W��
    public float detectionRadius = 1f;  // �G�����o���锼�a
    public float lifeTime = 5f;  // �e�̎���

    private void Start()
    {
        // �w�肵�����Ԍ�ɒe�������ō폜
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // �e�̈ʒu�𒆐S�Ɏw�肵�����a���̓G�����o����
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D hit in hits)
        {
            // ���̃I�u�W�F�N�g�̃^�O�� "Enemy" �ł���΁A�_���[�W��^����
            if (hit.CompareTag("Enemy"))
            {
                // EnemyHealth �R���|�[�l���g���擾
                EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

                // EnemyHealth �R���|�[�l���g�����݂���΃_���[�W��^����
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }

                // �e�̃I�u�W�F�N�g���폜����
                Destroy(gameObject);
                break;  // ��x���������珈�����I����
            }

            if (hit.CompareTag("BOSS"))
            {
                // EnemyHealth �R���|�[�l���g���擾
                BOSSHealth bossHealth = hit.GetComponent<BOSSHealth>();

                // EnemyHealth �R���|�[�l���g�����݂���΃_���[�W��^����
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(damageAmount);
                }

                // �e�̃I�u�W�F�N�g���폜����
                Destroy(gameObject);
                break;  // ��x���������珈�����I����
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Scene�r���[�Ō��o�͈͂�\������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
