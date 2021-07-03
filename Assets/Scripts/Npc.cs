using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public Item requestedItem;
    public int currentGold;
    public bool requestInProgress = true;
    public Inventory v_inventory;
    public Text requestText;
    public string v_texto;

    public void Start()
    {
        v_inventory = FindObjectOfType<Inventory>();
        currentGold = 10000;
        setRequestedItem();
    }

    public void Update()
    {
        if (requestedItem  != null)
        {
            if (requestInProgress)
            {
                v_texto = "Quiero la pocion: " + requestedItem.title;
                requestText.text = v_texto.ToString();
            }
            else
            {
                v_texto = "Gracias!";
                requestText.text = v_texto.ToString();
            }
        }
    }

    public void setRequestedItem()
    {
        requestedItem = new Item(v_inventory.RandomItem()); // Se envía el item aleatorio a la variable requestedItem
        Debug.Log("El NPC quiere el item: " + requestedItem.title);
    }

}
