using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Animator meuAnim;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
        meuAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
    }

    private void Movendo()
    {
        //Fazendo a movimenta��o
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        //Mudando a anima��o
        meuAnim.SetFloat("Horizontal", movement.x);
        meuAnim.SetFloat("Vertical", movement.y);
        meuAnim.SetFloat("Speed", movement.magnitude);

        //Aplicando a movimenta��o ao transforme
        transform.position += movement * speed * Time.deltaTime;
    }
}
