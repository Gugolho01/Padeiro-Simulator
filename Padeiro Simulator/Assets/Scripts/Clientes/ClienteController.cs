using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteController : MonoBehaviour
{
    //Variaveis para encontrar a bancada
    [SerializeField] private GameObject qualBancada;
    [SerializeField] private Transform ondeVai;
    [SerializeField] private bool bancaGO;

    //Pegando a sprite do cliente
    private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] clientes;
    [Range(0, 2)]
    [SerializeField] private int quem;

    //Caracteristicas do cliente
    [SerializeField] private float vel = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //Pegando a sprite
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = clientes[quem];
    }

    // Update is called once per frame
    void Update()
    {
        //Localizei a bancada e aqui faz ele ir at� ela
        if (bancaGO && ondeVai != null)
        {
            //Fazendo ele se mover para a bancada
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ondeVai.position.x, vel * Time.deltaTime / 5),
                                            Mathf.Lerp(transform.position.y, ondeVai.position.y, vel * Time.deltaTime / 5), 0);
            
            bancaGO = true;
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
