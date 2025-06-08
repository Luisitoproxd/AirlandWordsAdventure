using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Debug.Log("📱 Orientación forzada a VERTICAL.");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SalirDeLaAplicacion()
    {
        Debug.Log("Saliendo de la aplicación...");
        Application.Quit();
    }
}
