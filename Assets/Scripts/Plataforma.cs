using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Rigidbody2D rB2D;
    public float Speed = 10f;
    public float bounceForce = 10f;
    public Bola bolinha;
    public GAmever gameOver;

    private bool movendoEsquerda = false;
    private bool movendoDireita = false;

    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        bounceForce = 12;
        if (bolinha.pontos == 45)
        {
            bounceForce = 17;
        }
    }

    void Update()
    {
        // Movimento pelo teclado e toque na tela
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || movendoDireita)
        {
            rB2D.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || movendoEsquerda)
        {
            rB2D.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
    }

    // Métodos para os botões (Event Trigger)
    public void MoverEsquerdaPressionado()
    {
        movendoEsquerda = true;
    }

    public void MoverEsquerdaSolto()
    {
        movendoEsquerda = false;
    }

    public void MoverDireitaPressionado()
    {
        movendoDireita = true;
    }

    public void MoverDireitaSolto()
    {
        movendoDireita = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 platformCenter = GetComponent<Collider2D>().bounds.center;

            float hitFactor = (contactPoint.x - platformCenter.x) / (GetComponent<Collider2D>().bounds.size.x / 2);

            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                Vector2 bounceDirection = new Vector2(hitFactor, 1).normalized;
                ballRb.linearVelocity = bounceDirection * bounceForce;
            }
        }
    }
}