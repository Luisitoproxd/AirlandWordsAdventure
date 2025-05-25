using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI tex;

    internal void SumarPuntos(int cantidadPuntos)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        tex = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        puntos += Time.deltaTime;
        tex.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
