using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Purchase : MonoBehaviour
{
    public Shop v_shop;
    public Inventory v_inventory;
    void Start()
    {
        v_shop = FindObjectOfType<Shop>();
        v_inventory = FindObjectOfType<Inventory>();
    }
    // Start is called before the first frame update
    public void removeGoldFromPlayer()
    {
        v_inventory.GiveItem(1);//Agrega una nueva pocion roja EJEMPLO
        v_shop.SpendGold(30); //Agrega dinero restado al player EJEMPLO
        Debug.Log("Se agregó una pocion roja y se quitaron 30 monedas al Player.");
    }
}