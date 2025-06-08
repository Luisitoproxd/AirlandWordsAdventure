using UnityEngine;
using UnityEngine.SceneManagement;

public class ForzarOrientacionPorEscena : MonoBehaviour
{
   public string[] escenasHorizontales;

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
