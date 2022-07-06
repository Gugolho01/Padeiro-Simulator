using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    [SerializeField] private bool tenhoItem;
    [SerializeField] private bool queroItem = true;
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

            Instantiate(item, transform.position, Quaternion.identity);

            tenhoItem = true;
            queroItem = false;
        }

        item.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

}
