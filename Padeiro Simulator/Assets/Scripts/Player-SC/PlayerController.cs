using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Animator meuAnim;

    [SerializeField] private float speed;

    [SerializeField] private Transform naMaoObj;
    [SerializeField] private bool segurando;

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
        if (collision.gameObject.CompareTag("Comida"))
        {
            naMaoObj = collision.gameObject.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Comida"))
        {
            naMaoObj = null;
        }
    }
}
