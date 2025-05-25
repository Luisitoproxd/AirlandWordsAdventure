using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject panelUI; 
     public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelUI.SetActive(true);     
            Time.timeScale = 0f;         
        }
    }

 
    public void ReanudarJuego()
    {
        panelUI.SetActive(false);     
        Time.timeScale = 1f;           
        player.SetActive(false); 
       
    }
}
