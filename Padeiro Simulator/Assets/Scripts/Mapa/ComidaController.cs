using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] comidas;
    [SerializeField] private int qualComida;

    [SerializeField] private bool tenhoComida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tenhoComida)
        {
            spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.sprite = comidas[qualComida];
        }
    }

    public void QualComida(int n1 = 0)
    {
        qualComida = n1;
        tenhoComida = true;
    }

    public void OndeTo(Transform tra)
    {
        transform.position = tra.position;
    }
}
