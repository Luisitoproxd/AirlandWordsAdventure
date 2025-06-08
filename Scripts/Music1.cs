using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    ///  Metodo para detener la musica
    /// </summary>
    public void Detener()
    {
        Music.instancia.DetenerMusica();
    }

    /// <summary>
    ///  reanudar la musica
    /// </summary>
    public void play()
    {
        Music.instancia.Playmusic();
    }

    
}
