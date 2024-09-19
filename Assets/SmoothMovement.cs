using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed = 5.0f; // �ړ����x
    public float smoothTime = 0.3f; // ���炩���̎���

    private Vector3 targetPosition; // �ڕW�ʒu
    private Vector3 velocity = Vector3.zero; // ���x

    void Update()
    {
        // ���͂Ɋ�Â��ĖڕW�ʒu��ݒ�
        float moveX = Input.GetAxis("Horizontal"); // ���E�̓���
        float moveY = Input.GetAxis("Vertical"); // �㉺�̓���

        // �ړ��x�N�g�����v�Z
        Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;

        // ���݂̈ʒu���X�V
        targetPosition = transform.position + move;

        // �ڕW�ʒu�Ɍ������Ċ��炩�Ɉړ�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
