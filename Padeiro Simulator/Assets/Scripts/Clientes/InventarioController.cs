using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField] private GameObject[] item;

    [SerializeField] private bool tenhoItem;

    //Pegando o transforme do item que eu tenho
    private int queItem;

    //Quantos Itens criar
    [SerializeField] private int qtdItens = 4;
    private int sizeComida = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tenhoItem)
        {
            for (var f = 0; f < qtdItens; f++)
                item[f].transform.position = transform.position;
        }
    }

    public void CriandoItem()
    {
        if (!tenhoItem)
        {
            int f = 0;
            while (!tenhoItem)
            {
                //Pegando o preFab com a variavel item
                item[f] = Resources.Load<GameObject>("Comida");

                //transformando a variavel item em uma istance
                item[f] = Instantiate(item[f], new Vector3(transform.position.x + sizeComida, transform.position.y, transform.position.z), Quaternion.identity);

                sizeComida ++;

                //falando qual o item aleatório
                var i = Random.Range(0, 6);
                item[f].GetComponent<ComidaController>().QualComida(i);

                //Pegando o numero da comida que to pegando
                queItem = i;

                //Mostrando os itens
                item[f].SetActive(true);
                Debug.Log(f);

                f++;
                if(f >= qtdItens) { tenhoItem = true; }
            }
            //tenhoItem = true;
        }
    }

    //Informando ao cliente qual item ele tem no inventario
    public int QueItem()
    {
        return queItem;
    }

    public void MostrarPedido(bool m)
    {
        for(var f = 0; f < qtdItens; f++) { item[f].SetActive(m); }
        
        gameObject.SetActive(m);
    }
}
