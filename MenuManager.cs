using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // AUIDO
    public AudioSource StartSound;

    

    // Start is called before the first frame update
    void Start()
    {
        // referencia sonido Start
        StartSound = StartSound.GetComponent<AudioSource>();
       
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargaNivel(string pNombreNivel)
    { 
        StartSound.Play();
        StartCoroutine(Cargar(pNombreNivel));
        //SceneManager.LoadScene(pNombreNivel);
    }

    IEnumerator Cargar(string pNombreNivel)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(pNombreNivel);
    }




    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has salido del juego");
    }
}
