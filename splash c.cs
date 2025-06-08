 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class splashc : MonoBehaviour
{public Image imagenPulso;               // Imagen verde que pulsa
    public string nombreEscena;             // Escribe aquí el nombre de la escena desde el Inspector
    public float duracionPulso = 1.5f;      // Duración del efecto de pulso
    public float esperaAntesDeCambio = 1f;  // Espera antes de cambiar de escena

    private Color colorOriginal;

    void Start()
    {
        if (imagenPulso != null)
        {
            imagenPulso.gameObject.SetActive(false);
            colorOriginal = imagenPulso.color;
        }
    }

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

    IEnumerator EfectoPulsoYCambio()
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

