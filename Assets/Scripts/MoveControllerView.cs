using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
//using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class MoveControllerView : MonoBehaviour
{
    //private const float delay = 1.2f;
    private const float rotateAngle = 0.7f;

    [SerializeField] private GameObject root;

    //[SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float force = 8f;
    [SerializeField] private float rotateForce = 200f;

    [SerializeField] private bool isInJump;

    private float lastJump;
    private Animator anim;
    private Rigidbody rigidbody;
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Speed = Animator.StringToHash("Speed");

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (Mathf.Abs(x) > 0.01f)
        {
            Vector3 velocity = rigidbody.velocity;
            velocity = new Vector3(x * speed, velocity.y, velocity.z);
            rigidbody.velocity = velocity;
            anim.SetFloat(Speed, Mathf.Abs(x));

            if (x > 0)
            {
                if(root.transform.rotation.y < rotateAngle)
                {
                    root.transform.RotateAround(root.transform.position, Vector3.up, rotateForce * Time.deltaTime);
                }
            }
            else if(x<0)
            {
                if (root.transform.rotation.y > -rotateAngle)
                {
                    root.transform.RotateAround(root.transform.position, Vector3.up, -rotateForce * Time.deltaTime);
                }
            }
        }

        if (!isInJump && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(0, force, 0, ForceMode.Impulse);
            isInJump = true;
            anim.SetBool("Jump", true);
        }
        //else
        //{
        //    anim.SetFloat(Speed,0);
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        isInJump = false;
        anim.SetBool("Jump", false);
    }
}
