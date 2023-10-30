using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MoveControllerView : MonoBehaviour
{
    private const float delay = 1.2f;

    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float force = 8f;

    [SerializeField] private bool isInJump;

    private float lastJump;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (Mathf.Abs(x) > 0.01f)
        {
            Vector3 velocity = rigidbody.velocity;
            velocity = new Vector3(x * speed, velocity.y, velocity.z);
            rigidbody.velocity = velocity;
        }

        if (!isInJump && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(0, force, 0, ForceMode.Impulse);
            isInJump = true;
            anim.SetBool("Jump",true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isInJump = false;
    }
}
