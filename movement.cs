using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator animator;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    private float direccion = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = true;

    private bool botonIzquierdaPresionado = false;
    private bool botonDerechaPresionado = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }


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

    // Dirección solo se actualiza con botones
    if (botonIzquierdaPresionado)
        direccion = -1f;
    else if (botonDerechaPresionado)
        direccion = 1f;
    else
        direccion = 0f;
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

void FixedUpdate()
{
    // Tomamos el movimiento del teclado y el de los botones
    float inputTeclado = Input.GetAxis("Horizontal");
    float inputBoton = direccion; // viene de botones táctiles

    // Combinamos ambos: si hay input táctil, lo usamos; si no, usamos teclado
    float movimientoFinal = (inputBoton != 0f) ? inputBoton : inputTeclado;

    rb.velocity = new Vector2(movimientoFinal * runSpeed, rb.velocity.y);
}

    
    public void PresionarIzquierda() => botonIzquierdaPresionado = true;
    public void SoltarIzquierda() => botonIzquierdaPresionado = false;

    public void PresionarDerecha() => botonDerechaPresionado = true;
    public void SoltarDerecha() => botonDerechaPresionado = false;
}
