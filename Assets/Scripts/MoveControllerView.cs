using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MoveControllerView : MonoBehaviour
{
    private const float delay = 1.2f;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float force = 8f;

    [SerializeField] private bool isInJump;

    private float lastJump;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (Mathf.Abs(x) > 0.1f)
        {
            Vector3 velocity = GetComponent<Rigidbody>().angularVelocity;
            velocity = new Vector3(x * speed, velocity.y, velocity.z);
            GetComponent<Rigidbody>().velocity = velocity;
        }

        if (!isInJump && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(0, force, 0, ForceMode.Impulse);
            isInJump = true;
        }

        if (Mathf.Abs(GetComponent<Rigidbody>().angularVelocity.y) <= 0f)
        {
            isInJump = false;
        }
    }
}
