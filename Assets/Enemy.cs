using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �G�̍ő�̗�
    public int maxHealth = 30;
    // ���݂̗̑�
    private int currentHealth;

    // ���j�G�t�F�N�g��Prefab
    public GameObject destroyEffect;

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
        // ���j�G�t�F�N�g�𐶐�
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        // �G�̃I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
