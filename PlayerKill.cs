using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerKill : MonoBehaviour
{
    // AUIDO
    public AudioSource monedita;
    public AudioSource die;
    public AudioSource Background;

    // SOLO PARA UI
    public Text textomonedas;
    public Text textoTryText;
    public int FlashlightBattery = 0;


    Rigidbody miRigidBody;
    Vector3 posicionInicial;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        miRigidBody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

        // "" "" textoTryText
        textoTryText.enabled = false;

        // referencia sonido baterias
        monedita = monedita.GetComponent<AudioSource>();
        // referencia sonido die
        die = die.GetComponent<AudioSource>();
        // referencia sonido background
        Background = Background.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Enemy"))
        {
                Destroy(gameObject);
                die.Play();
                Background.Stop();
                textoTryText.enabled = true;
                Debug.Log("¡TU PUEDES! INTENTALO DE NUEVO. PRESIONA RELOAD GAME PARA VOLVER A EMPEZAR");

        }
        // Agarrar monedas e ir sumando la puntuación
        else if (otro.CompareTag("Battery"))
        {
            otro.gameObject.SetActive(false);
            monedita.Play();
            FlashlightBattery = FlashlightBattery + 1;
            textomonedas.text = "Batteries: " + FlashlightBattery;

        }
    }
}
