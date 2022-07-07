using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteController : MonoBehaviour
{
    //Variaveis para encontrar a bancada
    [SerializeField] protected bool fizPedido;
    [SerializeField] private GameObject qualBancada;
    private Transform ondeVai;
    private bool bancaGO;

    //Pegando a sprite do cliente
    private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] clientes;
    [Range(0, 2)]
    [SerializeField] private int quem;

    //Caracteristicas do cliente
    private float vel = 5f;

    //Inventory
    [SerializeField] private GameObject meuInventory;
    private int itemTenho;
    [SerializeField] private int quantosPedidos;

    // Start is called before the first frame update
    void Start()
    {
        //Pegando a sprite do Cliente
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = clientes[quem];
    }

    // Update is called once per frame
    void Update()
    {
        //Localizei a bancada e aqui faz ele ir até ela
        if (bancaGO && ondeVai != null && !fizPedido)
        {
            //Fazendo ele se mover para a bancada
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ondeVai.position.x, vel * Time.deltaTime / 5),
                                            Mathf.Lerp(transform.position.y, ondeVai.position.y, vel * Time.deltaTime / 5), 0);
            var dis = 3f;
            if(transform.position.x > ondeVai.position.x - dis && transform.position.x < ondeVai.position.x + dis &&
               transform.position.y > ondeVai.position.x - dis && transform.position.y < ondeVai.position.y + dis)
            {
                fizPedido = true;

                //Fazendo meu Inventário criar o itm quando chegar no local
                meuInventory.GetComponent<InventarioController>().CriandoItem();

                //Vendo qual o numero da sprite do item que tenho
                itemTenho = meuInventory.GetComponent<InventarioController>().QueItem();
            }
            bancaGO = true;
        }
        
        meuInventory.SetActive(fizPedido);
        meuInventory.GetComponent<InventarioController>().MostrarPedido(fizPedido);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bancada") && !bancaGO)
        {
            //pegando o gameObject da bancada
            qualBancada = collision.gameObject;

            //Pegando as variaveis da bancada para saber onde fazer o pedido
            bancaGO = qualBancada.GetComponent<BancadaController>().TenhoCliente();

            //Se tiver alguém não posso ir
            if (!bancaGO)
            {

                bancaGO = true;
                ondeVai = qualBancada.GetComponent<BancadaController>().LugarPedir();
            } else
            {
                bancaGO = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bancada") && bancaGO)
        {
            //Retirando as configue da bancada que devo ir
            qualBancada.GetComponent<BancadaController>().TenhoCliente(true);
            qualBancada = null;
            bancaGO = false;
            ondeVai = null;
            
        }
    }

}
