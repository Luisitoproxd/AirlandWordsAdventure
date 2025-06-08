using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hace que el objeto gire horizontalmente para mirar hacia la posición del jugador.
/// </summary>
public class Lokme : MonoBehaviour
{
    /// <summary>
    /// Referencia al transform del jugador.
    /// </summary>
    public Transform player; // Arrastra aquí el jugador desde el editor

    /// <summary>
    /// Componente SpriteRenderer del objeto que se va a voltear horizontalmente.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Inicializa las referencias necesarias al iniciar el juego.
    /// </summary>
    /// <remarks>
    /// Obtiene el componente SpriteRenderer asociado al objeto actual.
    /// </remarks>
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Actualiza la dirección visual del sprite en función de la posición del jugador.
    /// </summary>
    /// <remarks>
    /// Si el jugador está a la izquierda del objeto, voltea el sprite hacia la izquierda;
    /// si está a la derecha, lo voltea hacia la derecha.
    /// </remarks>
    void Update()
    {
        if (player != null)
        {
            if (player.position.x < transform.position.x)
            {
                // Jugador a la izquierda → mirar a la izquierda
                spriteRenderer.flipX = true;
            }
            else
            {
                // Jugador a la derecha → mirar a la derecha
                spriteRenderer.flipX = false;
            }
        }
    }
}