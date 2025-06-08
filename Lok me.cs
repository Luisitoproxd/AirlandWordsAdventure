using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lokme : MonoBehaviour
{
public Transform player; // arrastra aquí el jugador desde el editor
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
