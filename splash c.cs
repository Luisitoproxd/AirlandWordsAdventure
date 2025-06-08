using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controla un efecto visual de "pulso" en una imagen antes de cambiar de escena.
/// </summary>
/// <remarks>
/// Este script activa una imagen que pulsa visualmente y luego cambia a otra escena tras una breve espera.
/// </remarks>
public class splashc : MonoBehaviour
{
    /// <summary>
    /// Imagen que pulsará antes de cambiar de escena.
    /// </summary>
    public Image imagenPulso;

    /// <summary>
    /// Nombre de la escena a la que se cambiará. Se debe asignar desde el Inspector.
    /// </summary>
    public string nombreEscena;

    /// <summary>
    /// Duración total del efecto de pulso (en segundos).
    /// </summary>
    public float duracionPulso = 1.5f;

    /// <summary>
    /// Tiempo de espera adicional antes de cambiar de escena (en segundos).
    /// </summary>
    public float esperaAntesDeCambio = 1f;

    /// <summary>
    /// Color original de la imagen para restaurarlo después del pulso.
    /// </summary>
    private Color colorOriginal;

    /// <summary>
    /// Inicializa el componente, desactivando la imagen de pulso si está asignada.
    /// </summary>
    void Start()
    {
        if (imagenPulso != null)
        {
            imagenPulso.gameObject.SetActive(false);
            colorOriginal = imagenPulso.color;
        }
    }

    /// <summary>
    /// Llama al efecto de pulso y luego cambia a la escena especificada.
    /// </summary>
    /// <remarks>
    /// Verifica que el nombre de la escena esté asignado y que exista en los Build Settings antes de cargarla.
    /// </remarks>
    public void MostrarPulsoYcambiar()
    {
        if (string.IsNullOrWhiteSpace(nombreEscena))
        {
            Debug.LogWarning("⚠️ No se ha asignado el nombre de la escena.");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(nombreEscena))
        {
            Debug.LogError("❌ La escena '" + nombreEscena + "' no está incluida en Build Settings.");
            return;
        }

        StartCoroutine(EfectoPulsoYCambio());
    }

    /// <summary>
    /// Corrutina que ejecuta el efecto de pulso visual y luego cambia de escena.
    /// </summary>
    /// <returns>Corrutina IEnumerator para el sistema de Unity.</returns>
    private IEnumerator EfectoPulsoYCambio()
    {
        imagenPulso.gameObject.SetActive(true);
        float tiempoTotal = 0f;

        while (tiempoTotal < duracionPulso)
        {
            float t = Mathf.PingPong(Time.time * 2f, 1f);
            imagenPulso.color = Color.Lerp(colorOriginal * 0.6f, colorOriginal * 1.5f, t);
            tiempoTotal += Time.deltaTime;
            yield return null;
        }

        imagenPulso.color = colorOriginal;
        imagenPulso.gameObject.SetActive(false);

        yield return new WaitForSeconds(esperaAntesDeCambio);

        SceneManager.LoadScene(nombreEscena);
    }
}
