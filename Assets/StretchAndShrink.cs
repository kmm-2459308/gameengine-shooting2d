using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchAndShrink : MonoBehaviour
{
    // Start is called before the first frame update
    public float stretchSpeed = 1.0f;            // �c�ɐL�т鑬�x
    public float shrinkSpeed = 1.0f;             // �����������Ȃ鑬�x
    public float minWidth = 0.1f;                // �����̍ŏ��l
    public float destroyThreshold = 0.1f;        // ������܂ł̃X�P�[���̍ŏ��l
    public float damageAmount = 10.0f;           // �_���[�W��
    public float damageAreaHorizontalMultiplier = 1.5f; // �_���[�W�G���A�̉����̊g���{��
    public float damageAreaVerticalMultiplier = 2.0f;   // �_���[�W�G���A�̏c���̊g���{��

    private Vector3 originalScale;               // �����X�P�[��
    private Rect damageArea;                     // �_���[�W�G���A

    void Start()
    {
        // �����X�P�[����ۑ�
        originalScale = transform.localScale;

        // �_���[�W�G���A��������
        UpdateDamageArea();
    }

    void Update()
    {
        // ���݂̃X�P�[�����擾
        Vector3 currentScale = transform.localScale;

        // �c�����ɃX�P�[���𑝉�������
        currentScale.y += stretchSpeed * Time.deltaTime;

        // ��������������
        currentScale.x -= shrinkSpeed * Time.deltaTime;

        // �������ŏ��l�ȉ��ɂȂ�Ȃ��悤�ɐ���
        if (currentScale.x < minWidth)
        {
            currentScale.x = minWidth;
        }

        // �I�u�W�F�N�g�̃X�P�[�����X�V
        transform.localScale = currentScale;

        // �_���[�W�G���A���X�V
        UpdateDamageArea();

        // �X�P�[�������ȉ��ɂȂ�����I�u�W�F�N�g���폜����
        if (currentScale.x <= destroyThreshold || currentScale.y <= destroyThreshold)
        {
            Destroy(gameObject); // �I�u�W�F�N�g���폜
        }

        // �_���[�W�G���A���́uEnemy�v�^�O�̃I�u�W�F�N�g�Ƀ_���[�W��^����
        ApplyDamage();
    }

    void UpdateDamageArea()
    {
        // �I�u�W�F�N�g�̃T�C�Y�Ɋ�Â��ă_���[�W�G���A���X�V
        Vector2 position = (Vector2)transform.position;
        Vector2 size = transform.localScale;

        // �����Əc���̊g���{����ݒ�
        Vector2 damageAreaSize = new Vector2(size.x * damageAreaHorizontalMultiplier, size.y * damageAreaVerticalMultiplier);
        damageArea = new Rect(position - damageAreaSize / 2, damageAreaSize);
    }

    void ApplyDamage()
    {
        // �_���[�W�G���A���̑S�Ẵ^�[�Q�b�g���擾
        Collider2D[] targets = Physics2D.OverlapAreaAll(damageArea.min, damageArea.max);

        foreach (var target in targets)
        {
            // �^�O���uEnemy�v�̃I�u�W�F�N�g�݂̂�ΏۂɃ_���[�W��^����
            if (target.CompareTag("Enemy"))
            {
                EnemyHealth health = target.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    health.TakeDamage((int)damageAmount);
                }
            }

            if (target.CompareTag("BOSS"))
            {
                BOSSHealth health = target.GetComponent<BOSSHealth>();
                if (health != null)
                {
                    health.TakeDamage((int)damageAmount);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // �G�f�B�^���Ń_���[�W�G���A��`�悷�邽�߂̐ݒ�
        Gizmos.color = Color.red; // �F��Ԃɐݒ�
        Vector2 position = (Vector2)transform.position;
        Vector2 size = transform.localScale;
        Vector2 damageAreaSize = new Vector2(size.x * damageAreaHorizontalMultiplier, size.y * damageAreaVerticalMultiplier);
        Rect areaRect = new Rect(position - damageAreaSize / 2, damageAreaSize);

        // �_���[�W�G���A�̎l����`��
        Gizmos.DrawWireCube(areaRect.center, areaRect.size);
    }
}
