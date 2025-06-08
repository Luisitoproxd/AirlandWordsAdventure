using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla una animación de rotación y escalado sobre un objeto,
/// además de reproducir un sonido al presionar un botón.
/// </summary>
public class Codigo : MonoBehaviour
{
    /// <summary>
    /// Velocidad de la animación.
    /// </summary>
    public float velocidad = 2f;

    /// <summary>
    /// Amplitud de la rotación en grados.
    /// </summary>
    public float amplitudRotacion = 5f;

    /// <summary>
    /// Escala mínima del objeto animado.
    /// </summary>
    public float escalaMin = 0.95f;

    /// <summary>
    /// Escala máxima del objeto animado.
    /// </summary>
    public float escalaMax = 1.05f;

    /// <summary>
    /// Transform del objeto que será animado.
    /// </summary>
    public Transform objetoAnimado;

    /// <summary>
    /// Escala original del objeto al iniciar.
    /// </summary>
    private Vector3 escalaInicial;

    /// <summary>
    /// Referencia al botón de UI que reproducirá un sonido al ser presionado.
    /// </summary>
    public Button boton;

    /// <summary>
    /// Clip de sonido que se reproducirá al hacer clic en el botón.
    /// </summary>
    public AudioClip sonidoClick;

    /// <summary>
    /// Componente de AudioSource utilizado para reproducir el sonido.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Inicializa componentes y registra eventos.
    /// </summary>
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

    /// <summary>
    /// Actualiza la animación del objeto cada frame.
    /// </summary>
    /// <remarks>
    /// Aplica una rotación oscilatoria y cambio de escala al objeto animado.
    /// </remarks>
    void Update()
    {
        if (objetoAnimado == null) return;

        float tiempo = Time.time * velocidad;

        // Rotación oscilatoria en el eje Z
        float angulo = Mathf.Sin(tiempo) * amplitudRotacion;
        objetoAnimado.rotation = Quaternion.Euler(0f, 0f, angulo);

        // Escalado oscilatorio entre escalaMin y escalaMax
        float escala = Mathf.Lerp(escalaMin, escalaMax, (Mathf.Sin(tiempo) + 1f) / 2f);
        objetoAnimado.localScale = escalaInicial * escala;
    }

    /// <summary>
    /// Reproduce el sonido de clic si el clip está asignado.
    /// </summary>
    /// <remarks>
    /// Este método se llama al presionar el botón asignado.
    /// </remarks>
    void ReproducirSonido()
    {
        if (sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }
    }
}