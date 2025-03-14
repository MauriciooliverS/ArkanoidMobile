using UnityEngine;

public class ContaCoisas : MonoBehaviour
{  [Header("Configuração para Contagem")]
    public string tagParaContar = "Bases";  // Defina a tag dos objetos no Inspector
    public string nomeBase = "NomeBase";  // Parte do nome dos objetos
    public MonoBehaviour scriptParaContar; // Arraste o script desejado no Inspector

    void Start()
    {
        ContarObjetos();
    }

    void ContarObjetos()
    {
        // Contar objetos pela Tag
        int quantidadeTag = GameObject.FindGameObjectsWithTag(tagParaContar).Length;
        Debug.Log("🔹 Objetos com a tag '" + tagParaContar + "': " + quantidadeTag);

       
        
}
}

