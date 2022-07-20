using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public Item[] item;

    public GameObject mouseItem;

    public void DragItem( GameObject button )
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }
    public void DropItem( GameObject button)
    {
        if(mouseItem != null)
        {
            //pegando as informa��es de onde ele veio
            Transform aux = mouseItem.transform.parent;

            //mudando de pai pegando da a��o do mouse, trocando os dois
            mouseItem.transform.SetParent(button.transform.parent);
            //pegando as informa��es antigase do item
            button.transform.SetParent(aux);
        }
    }
}
