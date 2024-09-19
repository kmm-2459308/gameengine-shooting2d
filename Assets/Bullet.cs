using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // �e�̑��x
    public float randomDirectionOffset = 0.5f; // �����_���ȕ����̃I�t�Z�b�g

    private Vector2 direction; // �e�̈ړ�����

    void Start()
    {
        // �����_���ȕ����𐶐�
        float randomX = Random.Range(-randomDirectionOffset, randomDirectionOffset);
        float randomY = Random.Range(-1f, -0.5f); // Y�����͉������Ɍ���
        direction = new Vector2(randomX, randomY).normalized; // ���K�����ĕ�����ݒ�
    }

    void Update()
    {
        // �e���w�肳�ꂽ�����Ɉړ�
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // ��ʊO�ɏo����폜
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
        {
            Destroy(gameObject);
        }
    }
}
