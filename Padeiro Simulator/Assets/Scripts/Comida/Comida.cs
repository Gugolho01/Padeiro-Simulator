using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comida : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] comidas;

    [SerializeField] private int n1;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = comidas[n1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
