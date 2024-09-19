using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGaugeController : MonoBehaviour
{
    public Image skillGaugeImage;  // �Q�[�W��Image�R���|�[�l���g
    public Button skillButton;     // �K�E�Z�{�^����Button�R���|�[�l���g
    public GameObject skillPrefab; // �K�E�Z�̃v���n�u
    public Transform shootPoint;   // ���ˈʒu�i�v���C���[�̈ʒu�j

    public float fillSpeed = 0.1f;  // �Q�[�W�̗��܂�X�s�[�h
    public float maxGauge = 1f;     // �Q�[�W�̍ő�l�i�ʏ��1.0f�j

    private float currentGauge = 0f; // ���݂̃Q�[�W�̒l

    void Start()
    {
        // �K�E�Z�{�^���ɃC�x���g���X�i�[��ǉ�
        skillButton.onClick.AddListener(ActivateSkill);
    }

    void Update()
    {
        // �Q�[�W�����X�ɗ��߂�
        if (currentGauge < maxGauge)
        {
            currentGauge += fillSpeed * Time.deltaTime;
            currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge); // �Q�[�W�̒l�𐧌�
            UpdateGaugeUI();
        }

        // �X�y�[�X�L�[�ŕK�E�Z�𔭓�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateSkill();
        }
    }

    private void UpdateGaugeUI()
    {
        // �Q�[�W��UI���X�V
        if (skillGaugeImage != null)
        {
            skillGaugeImage.fillAmount = currentGauge / maxGauge;
        }
    }

    private void ActivateSkill()
    {
        // �Q�[�W�����^���ł���ΕK�E�Z�𔭓�
        if (currentGauge >= maxGauge)
        {
            Debug.Log("�K�E�Z�����I");

            // �K�E�Z�𔭎�
            ShootSkill();

            // �Q�[�W�����Z�b�g
            currentGauge = 0f;
            UpdateGaugeUI();
        }
        else
        {
            Debug.Log("�Q�[�W���s�����Ă��܂��I");
        }
    }

    private void ShootSkill()
    {
        if (skillPrefab != null && shootPoint != null)
        {
            // �K�E�Z�̃C���X�^���X�𐶐�
            GameObject skill = Instantiate(skillPrefab, shootPoint.position, shootPoint.rotation);

            // �K�E�Z�ɗ͂�������
            Rigidbody2D rb = skill.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // �K�E�Z�̔��˕����Ɨ͂�ݒ�
                Vector2 direction = shootPoint.up; // �v���C���[�̏�����ɔ���
                float force = 10f; // �K�E�Z�̔��˗́i�����\�j
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
    }
}
