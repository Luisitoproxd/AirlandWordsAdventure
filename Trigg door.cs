using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggdoor : MonoBehaviour
{

    public string nombreEscenaACargar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Cambia la escena sin importar qué objeto entró
        SceneManager.LoadScene(nombreEscenaACargar);
    }
}
