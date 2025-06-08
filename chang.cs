using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador para el cambio de escenas con transiciones de fundido (fade).
/// </summary>
public class chang : MonoBehaviour
{
    /// <summary>
    /// Referencia al CanvasGroup utilizado para la transición de fundido.
    /// </summary>
    public CanvasGroup pantallaNegra;

    /// <summary>
    /// Método llamado al iniciar el script. Inicia el efecto de fundido de entrada.
    /// </summary>
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// Cambia inmediatamente a una nueva escena especificada.
    /// </summary>
    /// <param name="nombreEscena">Nombre de la escena a cargar.</param>
    /// <remarks>
    /// Esta transición no utiliza efecto de fundido. Para transiciones suaves, usar FadeOut.
    /// </remarks>
    public void CambiarAEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    /// <summary>
    /// Corrutina que realiza el efecto de fundido de entrada (pantalla negra a visible).
    /// </summary>
    /// <returns>IEnumerator para la corrutina.</returns>
    /// <remarks>
    /// Disminuye gradualmente la opacidad de la pantalla negra al iniciar la escena.
    /// </remarks>
    IEnumerator FadeIn()
    {
        pantallaNegra.alpha = 1;
        while (pantallaNegra.alpha > 0)
        {
            pantallaNegra.alpha -= Time.deltaTime;
            yield return null;
        }
        pantallaNegra.blocksRaycasts = false;
    }

    /// <summary>
    /// Corrutina que realiza el efecto de fundido de salida (visible a pantalla negra) y cambia de escena.
    /// </summary>
    /// <param name="escena">Nombre de la escena a la que se cambiará una vez completado el fundido.</param>
    /// <returns>IEnumerator para la corrutina.</returns>
    /// <remarks>
    /// Aumenta gradualmente la opacidad de la pantalla negra antes de cambiar de escena.
    /// </remarks>
    IEnumerator FadeOut(string escena)
    {
        pantallaNegra.blocksRaycasts = true;
        while (pantallaNegra.alpha < 1)
        {
            pantallaNegra.alpha += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(escena);
    }

    /// <summary>
    /// Cierra la aplicación.
    /// </summary>
    /// <remarks>
    /// Solo funcionará fuera del editor. En el editor, solo se mostrará un mensaje en consola.
    /// </remarks>
    public void SalirDeLaAplicacion()
    {
        Debug.Log("Saliendo de la aplicación...");
        Application.Quit();
    }
}