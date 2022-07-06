using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject PegandoItem(bool aleatorio = false, int n1 = 0)
    {
        var preFab = Resources.Load<GameObject>("Comida");
        var item = Instantiate(preFab, Vector3.zero, Quaternion.identity);

        if (aleatorio)
        {
            n1 = Random.Range(0, 6);

            item.GetComponent<ComidaController>().QualComida(n1);
        }

        return Instantiate(preFab, Vector3.zero, Quaternion.identity);
    }
    
}
