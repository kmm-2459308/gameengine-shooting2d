using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed = 2.0f; // �w�i�̃X�N���[�����x
    public Transform[] backgrounds;  // �w�i�^�C���̔z��
    private float backgroundHeight;  // �w�i�̍���

    private void Start()
    {
        // �ŏ��̔w�i�̍������擾
        backgroundHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        // �w�i���c�Ɉړ�������
        foreach (Transform background in backgrounds)
        {
            background.position += Vector3.down * scrollSpeed * Time.deltaTime;

            // �w�i����ʊO�ɏo����Ĕz�u
            if (background.position.y <= -backgroundHeight)
            {
                background.position += Vector3.up * (backgroundHeight * backgrounds.Length);
            }
        }
    }
}
