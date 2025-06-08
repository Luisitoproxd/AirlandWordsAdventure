using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Cambia la orientación de la pantalla según la escena actual cargada.
/// </summary>
/// <remarks>
/// Si el nombre de la escena actual está en el arreglo <c>escenasHorizontales</c>, 
/// se fuerza la orientación horizontal. En caso contrario, se usa orientación vertical.
/// </remarks>
public class ForzarOrientacionPorEscena : MonoBehaviour
{
    /// <summary>
    /// Lista de nombres de escenas que deben mostrarse en orientación horizontal.
    /// </summary>
    public string[] escenasHorizontales;

    /// <summary>
    /// Método llamado al iniciar la escena. Cambia la orientación de la pantalla según la escena activa.
    /// </summary>
    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;

        if (EsEscenaHorizontal(escenaActual))
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Debug.Log("🌐 Escena " + escenaActual + " en horizontal.");
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Debug.Log("📱 Escena " + escenaActual + " en vertical.");
        }
    }

    /// <summary>
    /// Determina si una escena específica está en la lista de escenas horizontales.
    /// </summary>
    /// <param name="nombreEscena">Nombre de la escena a verificar.</param>
    /// <returns>Devuelve <c>true</c> si la escena está configurada como horizontal; de lo contrario, <c>false</c>.</returns>
    private bool EsEscenaHorizontal(string nombreEscena)
    {
        foreach (string escena in escenasHorizontales)
        {
            if (escena == nombreEscena)
                return true;
        }
        return false;
    }
}
