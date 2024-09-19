using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2D : MonoBehaviour
{
    private Vector3 offset;      // �I�u�W�F�N�g�Ɠ��͈ʒu�̃I�t�Z�b�g
    private Camera cam;          // �J����
    private bool isDragging;     // �h���b�O�����ǂ����̃t���O

    void Start()
    {
        // ���C���J�������擾
        cam = Camera.main;
    }

    void Update()
    {
        // �}�E�X�{�^���܂��̓^�b�`�̌��o
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Vector2 inputPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                // �^�b�`�̏ꍇ
                inputPosition = Input.GetTouch(0).position;
            }

            // �X�N���[�����W���烏�[���h���W�ɕϊ�
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, cam.nearClipPlane));
            Vector2 touchPosition = new Vector2(worldPosition.x, worldPosition.y);

            // �I�u�W�F�N�g���^�b�`�܂��̓N���b�N���ꂽ�ꍇ
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null && collider.OverlapPoint(touchPosition))
            {
                isDragging = true;
                offset = transform.position - new Vector3(touchPosition.x, touchPosition.y, transform.position.z);
            }
        }

        // �h���b�O���̏���
        if (isDragging)
        {
            Vector2 inputPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                // �^�b�`�̏ꍇ
                inputPosition = Input.GetTouch(0).position;
            }

            // �X�N���[�����W���烏�[���h���W�ɕϊ�
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, cam.nearClipPlane));
            Vector2 touchPosition = new Vector2(worldPosition.x, worldPosition.y);

            // �I�u�W�F�N�g�̈ʒu���X�V
            transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z) + offset;

            // �}�E�X�{�^���܂��̓^�b�`���I�������ꍇ
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                isDragging = false;
            }
        }
    }
}
