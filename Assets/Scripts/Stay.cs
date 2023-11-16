using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    public GameObject gumbo;

    private void OnTriggerStay()
    {
        gumbo.transform.position += gumbo.transform.forward*Time.deltaTime;
    }
}
