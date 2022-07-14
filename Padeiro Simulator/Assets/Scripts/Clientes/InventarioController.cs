using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    [SerializeField] private bool tenhoItem;

    //Pegando o transforme do item que eu tenho
    private int queItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tenhoItem)
        {
            item.transform.position = transform.position;
        }
        CriandoItem();
    }

    public void CriandoItem()
    {
        if(!tenhoItem)
        {
            //Pegando pelo resources o preFab da coimida
            item = Resources.Load<GameObject>("Comida");

            //transformando a variavel item em uma istance
            item = Instantiate(item, transform.position, Quaternion.identity);

            //falando qual o item aleatório
            var i = Random.Range(0, 6);

            //INformando pra comida qual a que quero
            item.GetComponent<ComidaController>().QualComida(i);

            //Pegando o numero da comida que to pegando
            queItem = i;

            //Mostrando os itens
            item.SetActive(true);

            tenhoItem = true;
        }
    }

    //Informando ao cliente qual item ele tem no inventario
    public int QueItem()
    {
        return queItem;
    }

    public void MostrarPedido(bool m)
    {
        item.SetActive(m);
        
        gameObject.SetActive(m);
    }
}
