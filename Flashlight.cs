using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class Flashlight : MonoBehaviour
{
    public KeyCode flashlightkey = KeyCode.Mouse0;
    public float batterylifesec = 60f; //(60 segundos dura bateria de la camara) 

    public float maxIntensity = 1f;
    private readonly float intensity = 1f;

    private float batteryLife;
    private bool isActive;

    public AudioSource myAudioSource;
    private Light myLight;

    private void Start()
    {
        myAudioSource = myAudioSource.GetComponent<AudioSource>();
        myLight = GetComponent<Light>();
        batteryLife = myLight.intensity;


    }

    void Update()
    {
        if (Input.GetKeyDown(flashlightkey))
        {
            isActive = !isActive;
            myAudioSource.Play();
        }

        if (isActive)
        {
            
            myLight.enabled = true;
            myLight.intensity -= batteryLife / batterylifesec * Time.deltaTime;
        }
        else
        {
            myLight.enabled = false;
        }
    }

    public void AddBatteryLife(float _batterypower)
    {
        myLight.intensity += _batterypower;
        if (myLight.intensity > maxIntensity)
            myLight.intensity = maxIntensity;
    }
}

