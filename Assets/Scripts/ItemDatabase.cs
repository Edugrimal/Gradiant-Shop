using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
     public List<Item> v_items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return v_items.Find(item => item.id == id);
    }

    void BuildItemDatabase()
    {
        v_items = new List<Item>()
        {
            //      ID/ Nombre/     Descripcion/  venta / compra
            new Item(1,"Red Potion", "Aumenta poder.", 100, 80),
            new Item(2,"Blue Potion", "Recupera Magia.", 100, 80),
            new Item(3,"Yellow Potion", "Daño espaciol.", 100, 80),
            new Item(4,"Magenta Potion", "Aumenta poder Magia.", 240, 180),
            new Item(5,"Green Potion", "Recupera Vida.", 240, 180)
        };
    }
}
