using UnityEngine;

public class Enemy : MonoBehaviour
{
 public GameObject panelUI;          // Panel que se mostrará
    public float tiempoVisible = 3f;    // Tiempo que estará visible

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mostrar el panel sin comparar ningún tag
        panelUI.SetActive(true);

        // Ocultarlo después de cierto tiempo
        Invoke("OcultarPanel", tiempoVisible);
    }

    private void OcultarPanel()
    {
        panelUI.SetActive(false);
    }
}
