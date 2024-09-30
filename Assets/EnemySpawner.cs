using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1Prefab;         // �G�L�����N�^�[�̃v���n�u
    public float spawnInterval = 2.0f;     // �G���o������Ԋu�i�b�j
    public float minXPosition = -5.0f;     // �G�̏o���ʒu�̍ŏ�Y���W
    public float maxXPosition = 5.0f;      // �G�̏o���ʒu�̍ő�Y���W
    public float spawnYPosition = 10.0f;   // �G���o������X���W�i��ʊO�j

    private void Start()
    {
        // �G�����I�ɏo�������邽�߂̃R���[�`�����J�n
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // �G�̏o���ʒu�������_���Ɍ���
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0);

        // �G�L�����N�^�[���w�肵���ʒu�ɏo��������
        GameObject enemy = Instantiate(enemy1Prefab, spawnPosition, Quaternion.identity);

        enemy.transform.Rotate(180, 0, 0);
    }

}
