using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    [SerializeField] private bool tenhoItem = true;

    //Pegando o transforme do item que eu tenho
    private int queItem;

    //Quantos Itens criar
    [SerializeField] private List<int> qtdItens;

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
    }

    public void CriandoItem()
    {
        if (!tenhoItem)
        {
            //Pegando o preFab com a variavel item
            item = Resources.Load<GameObject>("Comida");

            //transformando a variavel item em uma istance
            item = Instantiate(item, transform.position, Quaternion.identity);

            //Pegando o numero da comida que to pegando
            queItem = item.GetComponent<ComidaController>().queComida();
            Debug.Log(queItem + " item, no Inventory");
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
    }
}
