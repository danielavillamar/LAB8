using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Player;
    public static bool isAlive;
    Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        posicionInicial = Player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
        }
        else
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Player = Instantiate(prefab, posicionInicial, Quaternion.identity);
                isAlive = true;
            }
        }

    }
}
