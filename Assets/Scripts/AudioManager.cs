using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip gameOverSound; // Asigna el sonido en el inspector

    void Start()
    {
        // Verifica si el objeto tiene un componente AudioSource adjunto
        AudioSource audioSource = GetComponent<AudioSource>();

        // Si no tiene un componente AudioSource, añádelo y configúralo
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asigna el sonido al AudioSource desde el inspector
        audioSource.clip = gameOverSound;

        // Reproduce el sonido al iniciar el escenario de game over
        audioSource.Play();
    }
}
