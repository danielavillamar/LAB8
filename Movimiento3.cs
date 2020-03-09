using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento3 : MonoBehaviour
{
    public float velocidad;
    private Vector3 startPos;
    Rigidbody miRigidBody;
    private bool toco_piso;
    public GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 0.5f;
        startPos = transform.localPosition;
        miRigidBody = GetComponent<Rigidbody>();
       



    }

   

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(startPos.x , startPos.y + Mathf.Sin(Time.time) * velocidad, startPos.z);

    }
    private void FixedUpdate()
    {
#pragma warning disable CS8321 // La función local se declara pero nunca se usa
        void OnCollisionEnter(Collision collision)
#pragma warning restore CS8321 // La función local se declara pero nunca se usa
        {
            toco_piso = collision.gameObject.tag.Equals("piso");
        }

    }
}