using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LogicaJuego : MonoBehaviour
{
    [Header("Recursos del Jugador")]
    public int accionesRestantes = 5;
    public float puntosEnergia = 0;
    public float puntosContaminacion = 0;

    [Header("UI - Textos")]
    public TextMeshProUGUI textoAcciones;
    public TextMeshProUGUI textoEnergia;
    public TextMeshProUGUI textoContaminacion;
    public TextMeshProUGUI textoResultado;

    [Header("Botones de Energía")]
    public Button botonSolar;
    public Button botonEolica;
    public Button botonGas;
    public Button botonCarbon;
    public Button botonPetroleo;

    void Start()
    {
        ActualizarInterfaz();
        textoResultado.text = "";
    }

    // --- MÉTODOS PARA LOS BOTONES (Ahora desactivan el botón al usarse) ---

    public void SeleccionarSolar() { 
        ProcesarAccion(10, 2); 
        botonSolar.interactable = false; 
    }
    
    public void SeleccionarEolica() { 
        ProcesarAccion(15, 5); 
        botonEolica.interactable = false; 
    }

    public void SeleccionarGas() { 
        ProcesarAccion(25, 20); 
        botonGas.interactable = false; 
    }

    public void SeleccionarCarbon() { 
        ProcesarAccion(35, 40); 
        botonCarbon.interactable = false; 
    }

    public void SeleccionarPetroleo() { 
        ProcesarAccion(45, 60); 
        botonPetroleo.interactable = false; 
    }

    private void ProcesarAccion(float energiaGanada, float contaminacionSubida)
    {
        if (accionesRestantes > 0)
        {
            accionesRestantes--;
            puntosEnergia += energiaGanada;
            puntosContaminacion += contaminacionSubida;

            // Limitamos a 100
            puntosEnergia = Mathf.Clamp(puntosEnergia, 0, 100);
            puntosContaminacion = Mathf.Clamp(puntosContaminacion, 0, 100);

            ActualizarInterfaz();

            if (accionesRestantes <= 0)
            {
                EvaluarFinal();
            }
        }
    }

    void ActualizarInterfaz()
    {
        textoAcciones.text = "Acciones: " + accionesRestantes;
        textoEnergia.text = "Energía: " + puntosEnergia + "/100";
        textoContaminacion.text = "Contaminación: " + puntosContaminacion + "/100";
    }

    void EvaluarFinal()
    {
        // Bloqueamos todos los botones al final por seguridad
        DesactivarTodosLosBotones();

        if (puntosEnergia >= 50 && puntosContaminacion < 50)
        {
            textoResultado.text = "¡FINAL BUENO!\nSuficiente energía y planeta limpio.";
            textoResultado.color = Color.green;
        }
        else if (puntosEnergia >= 50 && puntosContaminacion >= 50)
        {
            textoResultado.text = "FINAL REGULAR.\nTienes energía, pero mucha contaminación.";
            textoResultado.color = Color.yellow;
        }
        else
        {
            textoResultado.text = "¡FINAL MALO!\nNo alcanzaste la energía o destruiste el ecosistema.";
            textoResultado.color = Color.red;
       }

       StartCoroutine(EsperarYIrACreditos());
    }

    IEnumerator EsperarYIrACreditos()
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        SceneManager.LoadScene("creditos"); // <--- 3. Cambia esto por el nombre exacto de tu escena
    }

    void DesactivarTodosLosBotones()
    {
        botonSolar.interactable = false;
        botonEolica.interactable = false;
        botonGas.interactable = false;
        botonCarbon.interactable = false;
        botonPetroleo.interactable = false;
    }
}