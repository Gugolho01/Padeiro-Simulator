using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private bool tenhoItem;

    //Pegando o transforme do item que eu tenho
    private int queItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tenhoItem)
        {
            //Pegando o preFab com a variavel item
            item = Resources.Load<GameObject>("Comida");

            //transformando a variavel item em uma istance
            item = Instantiate(item, transform.position, Quaternion.identity);

            //Pegando o numero da comida que to pegando
            queItem = item.GetComponent<ComidaController>().queComida();

            tenhoItem = true;
        }

        if (tenhoItem){
            item.transform.position = transform.position;
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
