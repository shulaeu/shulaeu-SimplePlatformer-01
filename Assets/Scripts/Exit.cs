using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject gumbo;
    
    private void onTriggerExit()
    {
        gumbo.SetActive(false);
    }
}
