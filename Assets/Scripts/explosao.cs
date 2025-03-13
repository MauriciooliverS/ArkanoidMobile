using UnityEngine;
using System.Collections;

public class explosao : MonoBehaviour
{
    private AudioSource audioSource;
    public Animator anim;
    public Transform bola;
    public AudioClip boomSom;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Explode", false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
    public void Explodir()
    {
       anim.SetBool("Explode", true);
       audioSource.PlayOneShot(boomSom);
       StartCoroutine(ExplodeEPause());
    }
     IEnumerator ExplodeEPause()
{
    
    yield return new WaitForSeconds(2f);
    Time.timeScale = 0;

}
void Update()
{
    transform.position = bola.position;
}
    
}
