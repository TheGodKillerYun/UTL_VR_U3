using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator Lapuerta;

    void OnTriggerEnter(Collider other)
    {
        // Solo se abre si el objeto que entra tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            Lapuerta.Play("abrirPSensor");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Solo se cierra si el que sale es el "Player"
        if (other.CompareTag("Player"))
        {
            Lapuerta.Play("cerrarPSensor");
        }
    }
}