using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chang : MonoBehaviour
{
    public CanvasGroup pantallaNegra;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void CambiarAEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
    IEnumerator FadeIn()
    {
        pantallaNegra.alpha = 1;
        while (pantallaNegra.alpha > 0)
        {
            pantallaNegra.alpha -= Time.deltaTime;
            yield return null;
        }
        pantallaNegra.blocksRaycasts = false;
    }
    
        IEnumerator FadeOut(string escena)
    {
        pantallaNegra.blocksRaycasts = true;
        while (pantallaNegra.alpha < 1)
        {
            pantallaNegra.alpha += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(escena);
    }
}
