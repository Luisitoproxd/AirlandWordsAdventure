using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla la orientación de la pantalla y permite salir de la aplicación.
/// </summary>
/// <remarks>
/// Este script establece la orientación de la pantalla en vertical al iniciar y 
/// proporciona un método para cerrar la aplicación desde un botón o evento.
/// </remarks>
public class Quit : MonoBehaviour
{
    /// <summary>
    /// Se ejecuta al inicio del juego. Fuerza la orientación de la pantalla a vertical.
    /// </summary>
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Debug.Log("📱 Orientación forzada a VERTICAL.");
    }

    /// <summary>
    /// Método llamado en cada frame. Actualmente no tiene funcionalidad.
    /// </summary>
    void Update()
    {
        // Este método se encuentra vacío por ahora.
    }

    /// <summary>
    /// Sale de la aplicación cuando es llamado.
    /// </summary>
    /// <remarks>
    /// En el editor de Unity, <c>Application.Quit()</c> no cerrará el editor, pero funciona correctamente en una build.
    /// </remarks>
    public void SalirDeLaAplicacion()
    {
        Debug.Log("Saliendo de la aplicación...");
        Application.Quit();
    }
}
