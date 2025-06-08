using UnityEngine;

/// <summary>
/// Controla la visualización de un panel UI cuando otro objeto entra en su zona de colisión (trigger).
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Panel de interfaz de usuario que se mostrará al activarse el trigger.
    /// </summary>
    public GameObject panelUI;

    /// <summary>
    /// Tiempo (en segundos) durante el cual el panel UI permanecerá visible.
    /// </summary>
    public float tiempoVisible = 3f;

    /// <summary>
    /// Método llamado automáticamente cuando otro collider 2D entra en el área de trigger.
    /// </summary>
    /// <param name="collision">Collider del objeto que ha entrado en el trigger.</param>
    /// <remarks>
    /// Activa el panel UI sin verificar etiquetas del objeto colisionador.
    /// Luego lo desactiva automáticamente después de un tiempo especificado.
    /// </remarks>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        panelUI.SetActive(true);
        Invoke("OcultarPanel", tiempoVisible);
    }

    /// <summary>
    /// Oculta el panel UI.
    /// </summary>
    /// <remarks>
    /// Este método se llama automáticamente después del tiempo definido por <c>tiempoVisible</c>.
    /// </remarks>
    private void OcultarPanel()
    {
        panelUI.SetActive(false);
    }
}