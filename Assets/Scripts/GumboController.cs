using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System.Random;
using System.ComponentModel.Design.Serialization;

public class GumboController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float movement = 0.1f;
    [SerializeField] private float i = transform.position.z;
    //i = GetComponent<transform.position.z>;
    
    public Transform[] movePoints;
    private int randomPoint;
    private float waitTime;
    public float startWaitTime;

    //[Range (-4.5f,5.5f) SerializeField] private float distance;

    private void Start()
    {
        randomPoint = Random.Range(0, movePoints.Length);
        waitTime = startWaitTime;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[randomPoint].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoints[randomPoint].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomPoint = Random.Range(0, movePoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Timeout.deltaTime;
            }
        }

        //if (transform.position.z < 5.0f && transform.position.z >= 0f)
        //{
        //    transform.position += new Vector3(0,0,movement) * speed * Time.deltaTime;
        //}
        //else if (transform.position.z > -5.5f)
        //{
        //    transform.position += new Vector3(0,0,-movement) * speed * Time.deltaTime;
        //}

        //for (transform.position.z = 0f; transform.position.z <5.0f; transform.position += new Vector3(0, 0, movement) * speed * Time.deltaTime)
        //{
        //    //transform.position += new Vector3(0, 0, movement) * speed * Time.deltaTime;
        //}
        //for (transform.position.z = 5.0f; transform.position.z > -5.5f; transform.position += new Vector3(0, 0, -movement) * speed * Time.deltaTime)
        //{
        //    //transform.position += new Vector3(0, 0, movement) * speed * Time.deltaTime;
        //}
        
        //for (i = 0; i < 5.0f; i++)
        //{
        //    transform.position += new Vector3(0, 0, movement) * speed * Time.deltaTime;
        //}
        //for (i = 0; i < 5.0f; i--)
        //{
        //    transform.position += new Vector3(0, 0, -movement) * speed * Time.deltaTime;
        //}
        
        


    }
}
