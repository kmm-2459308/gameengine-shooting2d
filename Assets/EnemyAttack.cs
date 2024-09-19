using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // �U���̃_���[�W��

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[�ɏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[��Health�X�N���v�g���擾���ă_���[�W��^����
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
