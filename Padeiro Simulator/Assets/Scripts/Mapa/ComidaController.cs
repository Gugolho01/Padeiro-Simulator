using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteR;    //Sprite que vai mostar
    [SerializeField] private Sprite[] comidas;          //Conjunto de imagens
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
            spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.sprite = comidas[qualComida];
        }
    }

    public void QualComida(int n1 = 0)
    {
        qualComida = n1;
        tenhoComida = true;
    }
}
