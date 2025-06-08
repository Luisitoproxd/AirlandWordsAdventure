using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// Controla y muestra el puntaje acumulado durante el juego.
/// </summary>
/// <remarks>
/// El puntaje se incrementa automáticamente con el tiempo y puede aumentarse manualmente.
/// </remarks>
public class Puntaje : MonoBehaviour
{
    /// <summary>
    /// Puntaje acumulado del jugador.
    /// </summary>
    private float puntos;

    /// <summary>
    /// Referencia al componente TextMeshProUGUI donde se mostrará el puntaje.
    /// </summary>
    private TextMeshProUGUI tex;

    /// <summary>
    /// Método no implementado para sumar puntos con un valor entero.
    /// </summary>
    /// <param name="cantidadPuntos">Cantidad de puntos a sumar (entero).</param>
    /// <exception cref="NotImplementedException">Lanza una excepción indicando que aún no se ha implementado.</exception>
    internal void SumarPuntos(int cantidadPuntos)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inicializa la referencia al componente TextMeshProUGUI.
    /// </summary>
    private void Start()
    {
        tex = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Aumenta el puntaje automáticamente con el tiempo y actualiza el texto en pantalla.
    /// </summary>
    private void Update()
    {
        puntos += Time.deltaTime;
        tex.text = puntos.ToString("0");
    }

    /// <summary>
    /// Suma una cantidad específica de puntos al total actual.
    /// </summary>
    /// <param name="puntosEntrada">Cantidad de puntos a sumar (decimal).</param>
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
