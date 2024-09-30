using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    // �G�̍ő�̗�
    public int maxHealth = 30;
    // ���݂̗̑�
    private int currentHealth;

    // �J�n���ɌĂ΂��
    void Start()
    {
        // ���݂̗̑͂��ő�̗͂ŏ�����
        currentHealth = maxHealth;
    }

    // �_���[�W���󂯂��Ƃ��ɌĂяo��
    public void TakeDamage(int damage)
    {
        // ���݂̗̑͂�����������
        currentHealth -= damage;

        // �̗͂�0�ȉ��ɂȂ����ꍇ�̏���
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // �G�����S�����Ƃ��̏���
    void Die()
    {

    // �G�̃I�u�W�F�N�g���\���ɂ��邩�A�폜����Ȃǂ̏���
    // ���̗�ł́A�G�I�u�W�F�N�g���폜���܂�
        Destroy(gameObject);
    }
}
