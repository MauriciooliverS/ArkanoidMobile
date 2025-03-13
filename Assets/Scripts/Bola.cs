using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public bool estaVivo = true;
    public int pontos;
    public GAmever gameOver;
    public explosao explode;
    private AudioSource audioSource;
     public AudioClip tiroSom;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Morte"))
        {
            explode.Explodir();
            gameOver.MorrePlayer();
            estaVivo = false;
            

            
        }
        if(collision.gameObject.CompareTag("Bases"))
        {
             Destroy(collision.gameObject);
            pontos ++;
            audioSource.PlayOneShot(tiroSom);
        }
        
    }
    
}

    