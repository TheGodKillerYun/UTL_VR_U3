using UnityEngine;
using TMPro; // Necesario para el contador UI

public class GestorMisionNPC : MonoBehaviour
{
    [Header("Final de la Misión")]
    public GameObject npcFinal;    // Arrastra aquí tu objeto "r2"
    public GameObject canvasFinal; // Arrastra aquí tu "Canva3"

    [Header("Audio")]
    public AudioSource reproductorSonido; // Arrastra un AudioSource
    public AudioClip sonidoColocar;       // El sonido tipo "ding" o mágico

    [Header("Requisito Rúbrica: Contador")]
    public TextMeshProUGUI textoContador; // Un texto en UI que diga "0/3"

    private int objetosColocados = 0;

    void Start()
    {
        // Nos aseguramos de que el NPC final esté oculto al iniciar
        if(npcFinal != null) npcFinal.SetActive(false);
        if(canvasFinal != null) canvasFinal.SetActive(false);
        ActualizarContadorUI();
    }

    // Esta función la llamará cada pedestal cuando reciba un objeto
    public void ObjetoColocado()
    {
        objetosColocados++;
        ActualizarContadorUI();

        // Reproducir el sonido
        if(reproductorSonido != null && sonidoColocar != null)
        {
            reproductorSonido.PlayOneShot(sonidoColocar);
        }

        // Verificar si ya están los 3
        if(objetosColocados >= 3)
        {
            MisionCompletada();
        }
    }

    // Por si el jugador quita el objeto del pedestal antes de terminar
    public void ObjetoRetirado()
    {
        objetosColocados--;
        ActualizarContadorUI();
    }

    private void ActualizarContadorUI()
    {
        if(textoContador != null)
        {
            textoContador.text = "Objetos recuperados: " + objetosColocados + " / 3";
        }
    }

    private void MisionCompletada()
    {
        // ¡Aparece el NPC con su nueva pose y diálogo!
        if(npcFinal != null) npcFinal.SetActive(true);
        if(canvasFinal != null) canvasFinal.SetActive(true);
        Debug.Log("¡Misión de objetos completada!");
    }
}