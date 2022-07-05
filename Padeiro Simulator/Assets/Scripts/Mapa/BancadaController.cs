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

    public bool TenhoCliente()
    {
        if (!tenhoCliente)
        {
            tenhoCliente = true;
            return false;
        }

        return tenhoCliente;
    }
    public Transform LugarPedir()
    {
        return lugar;
    }
}
