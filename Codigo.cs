using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigo : MonoBehaviour
{
    public float velocidad = 2f; 
    public float amplitudRotacion = 5f;
    public float escalaMin = 0.95f;
    public float escalaMax = 1.05f;

    public RectTransform objetoAnimado; 
    private Vector3 escalaInicial;

    public Button sonido; 
    public AudioClip sonidoClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (sonido != null)
        {
            sonido.onClick.AddListener(ReproducirSonido);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el botón 'sonido' en el inspector.");
        }

       if (objetoAnimado != null)
        {
            escalaInicial = objetoAnimado.localScale;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el objetoAnimado en el inspector.");
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
        else
        {
            Debug.LogWarning("No se ha asignado el sonidoClick en el inspector.");
}
}

}