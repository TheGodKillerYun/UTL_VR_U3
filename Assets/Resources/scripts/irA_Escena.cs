using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Boton1 : MonoBehaviour
{
    public int Escena;

    public void Iniciar()
    {
        SceneManager.LoadScene(Escena);

    }

}
