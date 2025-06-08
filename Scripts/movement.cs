using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que controla el movimiento del personaje en 2D.
/// </summary>
/// <remarks>
/// Permite movimiento horizontal con teclado o botones táctiles, 
/// así como saltar solo cuando está en el suelo.
/// </remarks>
public class movement : MonoBehaviour
{
    /// <summary>
    /// Referencia al componente Animator para controlar animaciones.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Velocidad de desplazamiento horizontal del personaje.
    /// </summary>
    public float runSpeed = 5f;

    /// <summary>
    /// Fuerza con la que el personaje salta.
    /// </summary>
    public float jumpForce = 5f;

    /// <summary>
    /// Dirección de movimiento establecida por los botones táctiles (-1 izquierda, 1 derecha, 0 neutro).
    /// </summary>
    private float direccion = 0f;

    /// <summary>
    /// Referencia al componente Rigidbody2D para manipular la física.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Referencia al SpriteRenderer para voltear el sprite.
    /// </summary>
    private SpriteRenderer sr;

    /// <summary>
    /// Indica si el personaje está tocando el suelo.
    /// </summary>
    private bool isGrounded = true;

    /// <summary>
    /// Bandera para detectar si el botón izquierdo está presionado.
    /// </summary>
    private bool botonIzquierdaPresionado = false;

    /// <summary>
    /// Bandera para detectar si el botón derecho está presionado.
    /// </summary>
    private bool botonDerechaPresionado = false;

    /// <summary>
    /// Inicializa referencias a componentes y congela la rotación del Rigidbody.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Actualiza el estado del personaje en cada frame.
    /// </summary>
    void Update()
    {
        float inputTeclado = Input.GetAxis("Horizontal");
        float inputBoton = direccion;
        float movimientoFinal = (inputBoton != 0f) ? inputBoton : inputTeclado;

        animator.SetFloat("movement", Mathf.Abs(movimientoFinal));

        if (movimientoFinal > 0)
            sr.flipX = false;
        else if (movimientoFinal < 0)
            sr.flipX = true;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        if (botonIzquierdaPresionado)
            direccion = -1f;
        else if (botonDerechaPresionado)
            direccion = 1f;
        else
            direccion = 0f;
    }

    /// <summary>
    /// Detecta colisiones con el suelo para permitir el salto nuevamente.
    /// </summary>
    /// <param name="collision">Información sobre la colisión detectada.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    /// <summary>
    /// Aplica el movimiento físico del personaje usando la física de Unity.
    /// </summary>
    void FixedUpdate()
    {
        float inputTeclado = Input.GetAxis("Horizontal");
        float inputBoton = direccion;
        float movimientoFinal = (inputBoton != 0f) ? inputBoton : inputTeclado;

        rb.velocity = new Vector2(movimientoFinal * runSpeed, rb.velocity.y);
    }

    /// <summary>
    /// Se llama cuando se presiona el botón táctil de movimiento hacia la izquierda.
    /// </summary>
    public void PresionarIzquierda() => botonIzquierdaPresionado = true;

    /// <summary>
    /// Se llama cuando se suelta el botón táctil de movimiento hacia la izquierda.
    /// </summary>
    public void SoltarIzquierda() => botonIzquierdaPresionado = false;

    /// <summary>
    /// Se llama cuando se presiona el botón táctil de movimiento hacia la derecha.
    /// </summary>
    public void PresionarDerecha() => botonDerechaPresionado = true;

    /// <summary>
    /// Se llama cuando se suelta el botón táctil de movimiento hacia la derecha.
    /// </summary>
    public void SoltarDerecha() => botonDerechaPresionado = false;
}
