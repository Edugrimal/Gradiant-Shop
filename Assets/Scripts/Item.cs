using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int id;
    public string title;
    public string description;
    public int soldPrice;
    public int restockPrice;
    public Sprite icon;
    //public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string description, int soldPrice, int restockPrice)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Misc/" + title); //Carga el inventario de items
        this.soldPrice = soldPrice;
        this.restockPrice = restockPrice;
    }

    public Item(Item v_item)
    {
        this.id = v_item.id;
        this.title = v_item.title;
        this.description = v_item.description;
        this.icon = Resources.Load<Sprite>("Misc/" + v_item.title); //Carga el inventario de items
        this.soldPrice = v_item.soldPrice;
        this.restockPrice = v_item.restockPrice;
    }
}
