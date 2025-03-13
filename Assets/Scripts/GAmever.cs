using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class GAmever : MonoBehaviour
{
   public GameObject GameOver;
   public GameObject Ganhou;
   public GameObject Pontos;
   public GameObject Bola;
   public Bola bolinha;
    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoPontos2;
    public TextMeshProUGUI textoPontos3;
    public TextMeshProUGUI textoPontos4;
    public TextMeshProUGUI textoPontos5;
    public TextMeshProUGUI textoPontos6;
    public TextMeshProUGUI textoPontos7;
    private AudioSource audioSource;
    public AudioClip perdeSom; // Som de perder
      // Som de explosão
    public AudioClip ganhaSom; // Som de ganhar
    public AudioClip musicaFundoSom; // Música de fundo

    // Start é chamado antes da primeira execução do Update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Musicafundo();
        GameOver.SetActive(false); 
        Ganhou.SetActive(false); 
        Pontos.SetActive(true); 
        Bola.SetActive(true);
         AtualizarTexto();  
        Time.timeScale = 1;    
    }
    void Update()
    {
        AtualizarTexto(); 
        
    }
    public void VivePlayer()
    {
        Musicafundo();
        GameOver.SetActive(false); 
        SceneManager.LoadScene("Fase1");
        Bola.SetActive(true);
        Ganhou.SetActive(false); 
          
    }

    // Update is called once per frame
    public void MorrePlayer()
    {
        GameOver.SetActive(true);
        Bola.SetActive(false);
        PerdeSom();
        
    }
    public void VoltaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void AtualizarTexto()
    {
         textoPontos.text =  bolinha.pontos.ToString() + " Pontos" ;
         textoPontos2.text = bolinha.pontos.ToString() + " Pontos" ;
         textoPontos3.text = bolinha.pontos.ToString() + " Pontos" ;
         textoPontos4.text = bolinha.pontos.ToString() + " Pontos" ;
         if ( bolinha.pontos == 81 )
         {
            GanhaPlayer();
         }
    }
    
    public void GanhaPlayer()
    {
        Time.timeScale = 0;
        Ganhou.SetActive(true); 
        textoPontos5.text = bolinha.pontos.ToString() + " Pontos!!!" ;
        textoPontos6.text = bolinha.pontos.ToString() + " Pontos!!!" ;
        textoPontos7.text = bolinha.pontos.ToString() + " Pontos!!!" ;
        Pontos.SetActive(false);
        GanhaSom();
    }
    
    public void PerdeSom()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(perdeSom); 
        audioSource.loop = true; 
    }
    public void GanhaSom()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(ganhaSom);
        audioSource.loop = true; 
    }
    public void Musicafundo()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(musicaFundoSom); 
        audioSource.loop = true;  
    }
    
}
