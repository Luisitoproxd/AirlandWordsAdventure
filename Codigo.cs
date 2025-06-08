using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Codigo : MonoBehaviour
{
    public float velocidad = 2f; 
    public float amplitudRotacion = 5f;
    public float escalaMin = 0.95f;
    public float escalaMax = 1.05f;

    public Transform objetoAnimado; 
    private Vector3 escalaInicial;

    public Button boton; 
    public AudioClip sonidoClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (boton != null)
        {
            boton.onClick.AddListener(ReproducirSonido);
        }


       if (objetoAnimado != null)
        {
            escalaInicial = objetoAnimado.localScale;
        }

    }

    void Update()
    {
        if (objetoAnimado == null) return;

        float tiempo = Time.time * velocidad;

      
        float angulo = Mathf.Sin(tiempo) * amplitudRotacion;
        objetoAnimado.rotation = Quaternion.Euler(0f, 0f, angulo);

   
        float escala = Mathf.Lerp(escalaMin, escalaMax, (Mathf.Sin(tiempo) + 1f) / 2f);
        objetoAnimado.localScale = escalaInicial * escala;
    }

    void ReproducirSonido()
    {
        if (sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }
}

}