using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float fuerzaSalto;
    public GameManager gameManager;
    private Rigidbody2D rigidbody2D;
    public Animator animator;
    private bool saltando = false;

    private AudioSource sonidoSalto;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        sonidoSalto = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !saltando) // Verifica si el jugador no está actualmente en el proceso de salto
        {
            animator.SetBool("Saltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            saltando = true; // Establece la variable de salto en verdadero
            sonidoSalto.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstaculo")
        {
            gameManager.gameOver = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("Saltando", false);
            saltando = false;
        }
    }
}
