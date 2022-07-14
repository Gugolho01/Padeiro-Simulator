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
    [SerializeField] private GameObject meuInventoryTemp;
    [SerializeField] private List<int> itemTenho;
    [SerializeField] private List<GameObject> inventoryLocal;
    private int quantosPedidos = 3;
    private bool mostrarPedido;

    void Start()
    {
        //Pegando a sprite do Cliente
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = clientes[quem];
    }

    void Update()
    {
        Pedido();
    }

    private void Pedido() 
    {
        if (!fizPedido)
        {
            //Localizei a bancada e aqui faz ele ir at� ela
            if (bancaGO && ondeVai != null)
            {
                //Fazendo ele se mover para a bancada
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, ondeVai.position.x, vel * Time.deltaTime / 5),
                                                 Mathf.Lerp(transform.position.y, ondeVai.position.y, vel * Time.deltaTime / 5), 0);

                //Se estou perto do bal��o j� posso fazer o pedidop
                if (Vector3.Distance(transform.position, ondeVai.position) < .1f)
                {
                    //Criando varios invent�rio
                    for (int i = 1; i <= quantosPedidos; i++)
                    {
                        //Criando o invent�rio
                        var inve = Instantiate(meuInventoryTemp, meuInventoryPos.position, Quaternion.identity);

                        //Adicionando o meu inventory a uma lista para poder controlalo
                        inventoryLocal.Add(inve);

                        //Vendo que item tenho do inventory
                        itemTenho.Add(inve.GetComponent<InventarioController>().CriandoItem());
                    }
                    fizPedido = true;
                }
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

            //Se tiver algu�m n�o posso ir
            if (!bancaGO)
            {
                bancaGO = true;
                ondeVai = qualBancada.GetComponent<BancadaController>().LugarPedir();
            } else
            {
                bancaGO = false;
            }
        }


        //Fazendo os pedidos aparecerem em cima do cliente quando o player estiver na frente dele
        if (collision.gameObject.CompareTag("ColisorMaoPlayer"))
        {
            for (int i = 0; i <= inventoryLocal.Count; i++)
            {
                //Fazendo ele ficar em cima do cliente
                inventoryLocal[i].transform.position = meuInventoryPos.position;

                //Mostrando pedidos
                inventoryLocal[i].gameObject.GetComponent<InventarioController>().MostrarPedido(true);
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

        //Fazendo os pedidos desaparecerem em cima do cliente quando o player sair da frente dele
        if (collision.gameObject.CompareTag("ColisorMaoPlayer"))
        {
            for(int i = 0; i <= inventoryLocal.Count; i++)
            {
                //desaparecendo pedidos
                inventoryLocal[i].gameObject.GetComponent<InventarioController>().MostrarPedido(false);
            }
        }
    }
}
