using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoom : MonoBehaviour
{
    public Light luz;

    void Start()
    {
        luz.enabled = false;
    }


    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            luz.enabled = true;
        }

    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            luz.enabled = false;
        }
    }

}
