using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> playerItems = new List<Item>();
    [SerializeField]
    private UIInventory inventoryUI;
    ItemDatabase v_itemDatabase;

    private void Awake()
    {
        v_itemDatabase = FindObjectOfType<ItemDatabase>();
        
    }

    private void Start()
    {
        //items Principales con los que empiezas la primera ronda
        GiveItem(1); 
        GiveItem(2);
        GiveItem(3);
        GiveItem(4);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = v_itemDatabase.GetItem(id);
        Debug.Log("Le di un nuevo item llamado: " + itemToAdd.title);
        inventoryUI.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public Item RandomItem()
    {
        int maxValue = v_itemDatabase.MaxItemCount();
        int newItemID = Random.Range(1, maxValue); //Obtiene un numero entre 1 y el maxValue, que es el conteo de items en la lista de items.
        Item itemToAdd = v_itemDatabase.GetItem(newItemID);
        Debug.Log("Generé el item aleatorio: " + itemToAdd.title);
        return itemToAdd;
    }

    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);

        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
        }
    }
}
