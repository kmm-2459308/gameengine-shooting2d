using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyOnYPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public float yThreshold = -20f;  // Y���̈ʒu��臒l

    void Update()
    {
        // �I�u�W�F�N�g��Y���̈ʒu���`�F�b�N
        if (transform.position.y < yThreshold)
        {
            // �I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}
