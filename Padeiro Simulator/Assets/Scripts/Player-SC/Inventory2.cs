using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public Item[] item;

    public GameObject mouseItem;

    [SerializeField] private Transform transPlayer;

    public void DragItem( GameObject button )
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }
    public void DropItem( GameObject button)
    {
        if(mouseItem != null)
        {
            if(button.name.Equals("Drop"))
            {
                // O numero que ele pega � literalmente o nome
                int pos = int.Parse(mouseItem.name);
                //Pegando a posi��o do player
                
                Instantiate(item[pos].prefab, transPlayer.position, Quaternion.identity);
            } 
            else 
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
}
