using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    [SerializeField]
    private SlotPanel[] slotPanels;

    public void AddItemToUI(Item item)
    {
        foreach(SlotPanel sp in slotPanels)
        {
            if (sp.ContainsEmptySlot())
            {
                Debug.Log("Found empty slot");
                sp.AddNewItem(item);
                break;
            }
        }
    }
}
