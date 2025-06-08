using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que detecta colisiones con el jugador y lo destruye al impactar.
/// </summary>
public class damage : MonoBehaviour
{
    /// <summary>
    /// Método que se ejecuta automáticamente cuando otro objeto colisiona con este (en 2D).
    /// </summary>
    /// <param name="collision">Información sobre la colisión, incluyendo el objeto con el que se chocó.</param>
    /// <remarks>
    /// Si el objeto con el que se colisiona tiene la etiqueta "Player", se muestra un mensaje en consola
    /// y se destruye el objeto del jugador.
    /// </remarks>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player damage");
            Destroy(collision.gameObject);
        }
    }
}