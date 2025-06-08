using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musica;
    private AudioSource audioSource;

    public static Music instancia;

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
    public void DetenerMusica()
    {
        audioSource.Pause();
    }

    public void Playmusic()
    {
        audioSource.Play();
    }
}

