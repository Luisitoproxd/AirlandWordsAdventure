using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Cambia a una nueva escena cuando cualquier objeto entra en el área de colisión (trigger).
/// </summary>
/// <remarks>
/// Este script debe estar en un GameObject con un Collider2D marcado como trigger. 
/// Carga la escena cuyo nombre se indique en el Inspector.
/// </remarks>
public class Triggdoor : MonoBehaviour
{
    /// <summary>
    /// Nombre de la escena que se cargará cuando se active el trigger.
    /// </summary>
    public string nombreEscenaACargar;

    /// <summary>
    /// Se ejecuta cuando otro collider entra en el área del trigger.
    /// </summary>
    /// <param name="other">El Collider2D del objeto que entró en el trigger.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cambia la escena sin importar qué objeto entró
        SceneManager.LoadScene(nombreEscenaACargar);
    }
}
