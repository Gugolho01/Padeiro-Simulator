using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancadaController : MonoBehaviour
{
    public bool tenhoCliente;
    [SerializeField] public Transform lugar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Entregando a variavel para o cliente, se ele definir reste como true, a bancada voltara a não ter cliente
    public bool TenhoCliente(bool reset = false)
    {
        //Se eu não tenho cliente, vou definir que agora tenho, e vou falar que o cliente que me solicitou pode vir
        if (!tenhoCliente)
        {
            tenhoCliente = true;
            return false;
        }
        //Se definiram reset como true, é pq o cliente já fez o pedido e agora pode entrar outro
        if (reset)
        {
            tenhoCliente = false;
        }
        return tenhoCliente;
    }
    public Transform LugarPedir()
    {
        return lugar;
    }
}
