using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForwardBullet : MonoBehaviour
{
    public Rigidbody rb;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }
}
