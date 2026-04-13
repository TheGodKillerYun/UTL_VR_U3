using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class  Salir : MonoBehaviour
{
    public void SalirJuego()
    {
        // Cierra la aplicación compilada
        Application.Quit();

        // Solo para pruebas dentro del Editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}