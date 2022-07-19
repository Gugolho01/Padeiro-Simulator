using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacolaController : MonoBehaviour
{
    [SerializeField] private Sprite myImagePrincipal;
    [SerializeField] private Image myImage;             //Sprite que vai mostar
    [SerializeField] private Sprite[] sacolaComidas;    //Conjunto de imagens
    [SerializeField] private int qualComida;            //Numero da imagem

    [SerializeField] private bool tenhoComida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tenhoComida) 
        {
            myImage = GetComponent<Image>();
            myImage.sprite = sacolaComidas[qualComida];
        } else
        {
            myImage = GetComponent<Image>();
            myImage.sprite = myImagePrincipal;
        }
    }

    public void MudaImageSacola(int i = 0)
    {
        //Mudando a sprite da sacola
        qualComida = i;
        tenhoComida = true;
    }
}
