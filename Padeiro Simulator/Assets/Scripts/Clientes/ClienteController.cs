using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteController : MonoBehaviour
{
    //Variaveis para encontrar a bancada
    [SerializeField] private bool fizPedido;
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
    [SerializeField] private Transform meuInventoryPos;
    [SerializeField] private List<GameObject> meuInventory;
    [SerializeField] private GameObject meuInventoryTemp;
    [SerializeField] private List<int> itemTenho;
    [SerializeField] private int quantosPedidos = 4;
    [SerializeField] private bool fizTodosPedidos;

    void Start()
    {
        //Pegando a sprite do Cliente
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = clientes[quem];
    }

    void Update()
    {
        //FandoPedido();
        Pedido();
    }

    private void Pedido() 
    {
        if (!fizPedido)
        {
            //Localizei a bancada e aqui faz ele ir até ela
            if (bancaGO && ondeVai != null)
            {
                //Fazendo ele se mover para a bancada
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, ondeVai.position.x, vel * Time.deltaTime / 5),
                                                 Mathf.Lerp(transform.position.y, ondeVai.position.y, vel * Time.deltaTime / 5), 0);

                //Se estou perto do balção já posso fazer o pedidop
                if (Vector3.Distance(transform.position, ondeVai.position) < .1f)
                {
                    //Criando o inventário
                    var inve = Instantiate(meuInventoryTemp, meuInventoryPos.position, Quaternion.identity);
                    //aumentando o scale do inventario
                    inve.transform.localScale = new Vector3(inve.transform.localScale.x + quantosPedidos + 2, inve.transform.localScale.y, 1);

                    while (quantosPedidos >= 0)
                    { 
                        inve.GetComponent<InventarioController>().CriandoItem();

                        itemTenho.Add(inve.GetComponent<InventarioController>().QueItem());

                        quantosPedidos--;
                    }
                    fizPedido = true;
                }
            }
        }
    }

    private void FandoPedido()
    {
        if (fizPedido)
        {
            for (var inve = 0; inve <= quantosPedidos; inve++)
            {
                if (!fizTodosPedidos)
                {
                    var i = 0;
                    if (i <= quantosPedidos)
                    {
                        //Pegando o preFab com a variavel item
                        meuInventory[i] = Resources.Load<GameObject>("Inventory");
                        meuInventory[i] = Instantiate(meuInventory[i], meuInventoryPos.position, Quaternion.identity);

                        //transformando a variavel item em uma istance
                        meuInventory.Insert(i, meuInventory[i]);

                        i++;
                    }
                    if (i >= quantosPedidos) { fizTodosPedidos = true; }
                }
                //Fazendo o inventário ficar em cima do cliente
                meuInventory[inve].transform.position = meuInventoryPos.position;
            }
        }
        //Localizei a bancada e aqui faz ele ir até ela
        if (bancaGO && ondeVai != null && !fizPedido)
        {
            //Fazendo ele se mover para a bancada
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ondeVai.position.x, vel * Time.deltaTime / 5),
                                             Mathf.Lerp(transform.position.y, ondeVai.position.y, vel * Time.deltaTime / 5), 0);
            for (var inve = 0; inve <= quantosPedidos; inve++)
            {
                if (Vector3.Distance(transform.position, ondeVai.position) < .1f)
                {
                    fizPedido = true;

                    //Fazendo meu Inventário criar o itm quando chegar no local
                    meuInventory[inve].GetComponent<InventarioController>().CriandoItem();

                    //Vendo qual o numero da sprite do item que tenho
                    for (var i = 0; i <= quantosPedidos; i++)
                    {
                        //Colocando na lista de itens que tenho no inventario
                        itemTenho.Insert(i, meuInventory[inve].GetComponent<InventarioController>().QueItem());
                    }
                }
                bancaGO = true;
                meuInventory[inve].SetActive(fizPedido);
                meuInventory[inve].GetComponent<InventarioController>().MostrarPedido(fizPedido);
            }
        }
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
