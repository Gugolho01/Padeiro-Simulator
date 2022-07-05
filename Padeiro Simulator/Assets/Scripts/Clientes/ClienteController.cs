using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteController : MonoBehaviour
{
    //Variaveis para encontrar a bancada
    [SerializeField] private Transform ondeVai;
    [SerializeField] private bool bancaGO;

    //Pegando a sprite do cliente
    private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] clientes;
    [Range(0, 2)]
    [SerializeField] private int quem;

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
        
        if (bancaGO && ondeVai != null)
        {
            transform.position = ondeVai.position;
            bancaGO = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bancada"))
        {
            //Pegando as variaveis da bancada para saber onde fazer o pedido
            bancaGO = GetComponent<BancadaController>().TenhoCliente();

            //Se tiver alguém não posso ir
            if (!bancaGO)
            {
                bancaGO = true;
                ondeVai = GetComponent<BancadaController>().LugarPedir();
            } else
            {
                bancaGO = false;
            }
        }
    }
}
