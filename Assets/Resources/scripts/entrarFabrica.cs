using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class AccesoFabrica : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public int Escena;

    [Header("Componentes del Canvas")]
    public TMP_InputField campoContrasena;
    public GameObject mensajeError;

    [Header("Seguridad")]
    public string contrasenaCorrecta = "EnergiaLimpia"; 

    void Start()
    {
        if (mensajeError != null)
        {
            mensajeError.SetActive(false);
        }
    }

    public void VerificarContrasena()
    {
        if (campoContrasena.text == contrasenaCorrecta)
        {
            mensajeError.SetActive(false);
            
            SceneManager.LoadScene(Escena);
            Debug.Log("Acceso Concedido a la Fábrica");
        }
        else
        {
            mensajeError.SetActive(true);
            campoContrasena.text = ""; 
            Debug.Log("Contraseña Incorrecta");
        }
    }
}