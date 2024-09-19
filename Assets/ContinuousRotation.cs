using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 45f; // ��]���x�i�x/�b�j

    void Update()
    {
        // ��]�̂��߂̊p�x���v�Z
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // ��]��K�p
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
