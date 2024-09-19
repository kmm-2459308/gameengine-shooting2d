using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 45f; // ‰ñ“]‘¬“xi“x/•bj

    void Update()
    {
        // ‰ñ“]‚Ì‚½‚ß‚ÌŠp“x‚ğŒvZ
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // ‰ñ“]‚ğ“K—p
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
