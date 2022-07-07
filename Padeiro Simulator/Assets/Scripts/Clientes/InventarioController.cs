using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    private GameObject item;

    private bool tenhoItem;
    private bool queroItem = true;

    private Transform itemObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tenhoItem && queroItem) 
        {
            item = Resources.Load<GameObject>("Comida");

            itemObj = Instantiate(item, transform.position, Quaternion.identity).GetComponent<Transform>();

            tenhoItem = true;
            queroItem = false;
        }

        if (tenhoItem){
            itemObj.position = transform.position;
        }
    }
}
