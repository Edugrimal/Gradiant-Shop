using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public Item requestedItem;
    public int currentGold;
    public bool requestInProgress = true;


    public void Start()
    {
        currentGold = 10000;
        setRequestedItem();
    }

    public void setRequestedItem()
    {
        requestedItem = new Item(4, "Magenta Potion", "Aumenta poder Magia.", 240, 180);
    }


}
