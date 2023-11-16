using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject gumbo;

    private void OnTriggerEnter()
    {
        gumbo.SetActive(true);
    }
}
