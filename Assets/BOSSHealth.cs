using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSHealth : MonoBehaviour
{
    public int maxHealth = 30; // �G�̍ő�̗�
    private int currentHealth; // ���݂̗̑�

    // UI�C���[�W�̎Q��
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth; // �����̗͂��ő�̗͂Őݒ�
        UpdateHealthBar(); // ������Ԃ̃o�[���X�V
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �_���[�W���󂯂�
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �̗͂����ɂȂ�Ȃ��悤��

        UpdateHealthBar(); // �_���[�W���󂯂���Ƀo�[���X�V

        if (currentHealth <= 0)
        {
            Die(); // �̗͂�0�ɂȂ����玀�S����
        }
    }

    void Die()
    {
        Destroy(gameObject); // �G�̃I�u�W�F�N�g���폜
    }

    // �̗̓o�[�̒l���X�V���郁�\�b�h
    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth; // ���݂̗̑͂������Őݒ�
    }
}
