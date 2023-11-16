using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
//using static UnityEngine.Random;
//using static System.Random;
//using UnityEngine.Random;
//using System.Random;
using System.ComponentModel.Design.Serialization;
using Random = UnityEngine.Random;

public class GumboController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float movement = 0.1f;
    //[SerializeField] private float i = transform.position.z;
    //i = GetComponent<transform.position.z>;
    
    public Transform[] movePoints;
    //public Vector3[] movePoints;
    private int randomPoint;
    private float waitTime;
    public float startWaitTime;

    //[Range (-4.5f,5.5f) SerializeField] private float distance;

    private void Start()
    {
        //randomPoint = Random.Range(0, movePoints.Length);
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
                waitTime -= Time.deltaTime;
            }
        }
    }
}
