using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;



public class Movimiento1 : MonoBehaviour
{

    public float force = 5;
    public int monedas = 0;
    Rigidbody miRigidBody;
    Vector3 posicionInicial;
    private bool toco_piso;
    public GameObject player;
    bool haSalido;

    // AUIDO
    public AudioSource monedita;
    public AudioSource die;
    public AudioSource jump;
    public AudioSource win;
    public AudioSource Background;



    // SOLO PARA UI
    public Text textomonedas;
    public Text textovictoria;
    public Text textoTryText;

    // FOLLOW MOUSE
    NavMeshAgent agent;
  



    // Start is called before the first frame update
    void Start()
    {
        miRigidBody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

        // Para que textovictoria no apareza desde el principio..
        textovictoria.enabled = false;
        haSalido = false;
        // "" "" textoTryText
        textoTryText.enabled = false;

        // referencia sonido monedita
        monedita = monedita.GetComponent<AudioSource>();
        // referencia sonido die
        die = die.GetComponent<AudioSource>();
        // referencia sonido jump
        jump = jump.GetComponent<AudioSource>();
        // referencia sonido win
        win = win.GetComponent<AudioSource>();
        // referencia sonido background
        Background = Background.GetComponent<AudioSource>();

        // follow the mouse
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!haSalido)
        {
            // Control por medio de WASD o las flechas
            // float vertical = Input.GetAxis("Vertical");
            //float horizontal = Input.GetAxis("Horizontal");
            //miRigidBody.AddForce(horizontal * force, 0, vertical * force);

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    agent.SetDestination(hit.point);
                }
            }



            
        }

    }

    private void FixedUpdate()
    {
       

        // Salto de la pelota

        if (Input.GetKey(KeyCode.Space) && toco_piso)
        {
            jump.Play();
            miRigidBody.velocity = (new Vector3(0, 5, 0));
            toco_piso = false;

        }

    }

    void OnTriggerEnter(Collider otro)
    {
        // Espacio para que el jugador sepa que ha completado el laberinto
        if (otro.CompareTag("salida"))
        {
            win.Play();
            haSalido = true;
            textovictoria.enabled = true;

        }
        // Cada Goomba hace que el jugador pierda y apachando ENTER vuelve a crearse una instancia del jugador, eso si con menos monedas
        else if (otro.CompareTag("enemigo"))
        {
            if (monedas < 4)
            {
                Destroy(gameObject);
                die.Play();
                Background.Stop();
                textoTryText.enabled = true;
                Debug.Log("¡TU PUEDES! INTENTALO DE NUEVO. PRESIONA RELOAD GAME PARA VOLVER A EMPEZAR");
                monedas = 0;
                textomonedas.text = "Monedas: 0";
            }
            else if (monedas > 4)
            {
                Destroy(otro.gameObject);
            }

        }
        // Agarrar monedas e ir sumando la puntuación
        else if (otro.CompareTag("moneda"))
        {
            otro.gameObject.SetActive(false);
            monedita.Play();
            monedas = monedas + 1;
            textomonedas.text = "Monedas: " + monedas;



            Debug.Log("¡SIGUE AGARRANDO MONETAS!AGARRA MAS DE 4 PARA NO VOLVER A MORIR!");
        }
    }

    // Prevención de saltos infinitos
    private void OnCollisionEnter(Collision collision)
    {
        toco_piso = collision.gameObject.tag.Equals("piso");
    }

}
