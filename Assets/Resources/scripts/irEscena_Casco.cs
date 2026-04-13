using UnityEngine;
using UnityEngine.SceneManagement;

public class irEscena_Casco : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public int Escena;

    [Header("Validación del Casco")]
    [Tooltip("Arrastra aquí el objeto gorro2 que está dentro del XR Origin")]
    public GameObject cascoEnCabeza; 
    
    [Tooltip("Arrastra aquí el Canvas que tiene el mensaje de 'No puedes empezar'")]
    public GameObject canvasMensajeAdvertencia;

    void Start()
    {
        if (canvasMensajeAdvertencia != null)
        {
            canvasMensajeAdvertencia.SetActive(false);
        }
    }

    public void Iniciar()
    {
        if (cascoEnCabeza != null && cascoEnCabeza.activeInHierarchy)
        {
            SceneManager.LoadScene(Escena);
        }
        else
        {
            if (canvasMensajeAdvertencia != null)
            {
                canvasMensajeAdvertencia.SetActive(true);
            }
        }
    }
}