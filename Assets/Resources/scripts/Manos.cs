using UnityEngine;
using UnityEngine.InputSystem;

public class Manos : MonoBehaviour
{

    public InputActionProperty trigerValue;
    public InputActionProperty gripValue;
    public Animator controlAnimator;

    void Start()
    {
        // Aquí puedes inicializar cualquier cosa que necesites al comenzar el juego
    }
    
    void Update()
    {
        float trigger = trigerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();

        controlAnimator.SetFloat("Trigger", trigger);
        controlAnimator.SetFloat("Grip", grip);
    }

}
