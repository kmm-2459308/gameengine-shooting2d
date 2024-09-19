using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2.0f;       // �G�L�����N�^�[�̈ړ����x
    public float minDistanceToMove = 2.0f; // �ړ����鋗���̍ŏ��l
    public float maxDistanceToMove = 5.0f; // �ړ����鋗���̍ő�l

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = true;

    void Start()
    {
        // �G�L�����N�^�[�̏����ʒu��ۑ�
        startPosition = transform.position;

        // �ړ����鋗���������_���Ɍ���
        float distanceToMove = Random.Range(minDistanceToMove, maxDistanceToMove);

        // �c�����̖ڕW�ʒu��ݒ�
        targetPosition = startPosition + new Vector3(0, distanceToMove, 0);
    }

    void Update()
    {
        if (isMoving)
        {
            // �G�L�����N�^�[��ڕW�ʒu�Ɍ������Ĉړ�������
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // �ڕW�ʒu�ɓ��B���������`�F�b�N
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // �ڕW�ʒu�ɓ��B������ړ����~
                isMoving = false;
            }
        }
    }
}
