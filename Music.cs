using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla la reproducción de música de fondo persistente entre escenas usando el patrón Singleton.
/// </summary>
public class Music : MonoBehaviour
{
    /// <summary>
    /// Clip de audio que se reproducirá como música de fondo.
    /// </summary>
    public AudioClip musica;

    /// <summary>
    /// Componente AudioSource que reproduce el clip de música.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Instancia única del objeto Music para implementar el patrón Singleton.
    /// </summary>
    public static Music instancia;

    /// <summary>
    /// Método llamado cuando la instancia se activa por primera vez, incluso antes de Start.
    /// Se asegura de que solo haya una instancia persistente del objeto.
    /// </summary>
    /// <remarks>
    /// Si ya existe una instancia, se destruye la nueva. Si no, se configura como persistente entre escenas
    /// y comienza la reproducción del clip asignado.
    /// </remarks>
    void Awake()
    {
        // Asegurarse de que solo haya una instancia (singleton)
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject); // Si ya existe otra instancia, destruye esta
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }

    /// <summary>
    /// Pausa la reproducción de la música actual.
    /// </summary>
    /// <remarks>
    /// Útil para mutear la música sin detener completamente la aplicación.
    /// </remarks>
    public void DetenerMusica()
    {
        audioSource.Pause();
    }

    /// <summary>
    /// Reanuda la reproducción de la música si está pausada.
    /// </summary>
    /// <remarks>
    /// Solo tiene efecto si la música fue pausada previamente.
    /// </remarks>
    public void Playmusic()
    {
        audioSource.Play();
    }
}