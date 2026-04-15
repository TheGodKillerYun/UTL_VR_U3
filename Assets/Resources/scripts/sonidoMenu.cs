using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorSonidoEscena : MonoBehaviour
{
    private AudioSource audioSource;
    
    public string nombreEscenaSonido = "EscenaEspecial";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == nombreEscenaSonido)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}