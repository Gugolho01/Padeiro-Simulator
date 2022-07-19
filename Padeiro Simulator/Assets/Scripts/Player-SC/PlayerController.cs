using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator meuAnim;

    [SerializeField] private float speed;

    //Verificando se está segurando um item
    [SerializeField] private Transform naMaoObj;
    [SerializeField] private bool segurando;

    //Variaveis do inventory
    [SerializeField] private List<GameObject> productos;

    // Start is called before the first frame update
    void Start()
    {
        meuAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Movendo();
        CarregaItem();

        //Guardando item na sacola
        if (Input.GetKeyUp(KeyCode.R) && segurando && naMaoObj != null)
        {
            productos.Add(naMaoObj.gameObject);
            //Destroy(naMaoObj.gameObject);
            //GetComponent<SacolaController>().MudaImageSacola();

            //resetando coisas na mão do player
            naMaoObj = null;
            segurando = false;
        }
    }

    private void CarregaItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!segurando && naMaoObj != null)
            {
                segurando = true;
            }
            else
            {
                segurando = false;
            }
        }

        if (segurando)
        {
            naMaoObj.position = transform.position;
        }
    }

    private void Movendo()
    {
        //Fazendo a movimentação
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        //Mudando a animação
        meuAnim.SetFloat("Horizontal", movement.x);
        meuAnim.SetFloat("Vertical", movement.y);
        meuAnim.SetFloat("Speed", movement.magnitude);

        //Aplicando a movimentação ao transforme
        transform.position += movement * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Comida") && !segurando && !collision.gameObject.GetComponent<ComidaController>().SouDeInventario())
        {
            naMaoObj = collision.gameObject.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Comida") && !segurando)
        {
            naMaoObj = null;
        }
    }
}
