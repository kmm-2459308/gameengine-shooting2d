using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public float attackRadius = 5f; // �U���͈͂̔��a
    public int damageAmount = 10; // �U���̃_���[�W��
    public float damageInterval = 1f; // �_���[�W��^����Ԋu�i�b�j

    private void Update()
    {
        // �v���C���[�Ƀ_���[�W��^���鏈���𖈃t���[���`�F�b�N
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
                Destroy(gameObject); // ���̍s���폜���邱�ƂŁA�G�������Ŕj�󂳂�Ȃ��悤�ɂ���
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Gizmos���g���čU���͈͂�����
        Gizmos.color = Color.red; // �U���͈͂̐F
        Gizmos.DrawWireSphere(transform.position, attackRadius); // �͈͂�`��
    }
}
