using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour {
    public SlotPanel slotPanel;
    public Inventory inventory;

    public void CollectCraftResult()
    {
        slotPanel.EmptyAllSlots(); // Se manda llamar el eliminado de la lista del craftingtable cuando se dragndrop el nuevo item combinado
        //Aqui se agrega un nuevo item a la lista del inventorio, cuando se craftea un item y ese se dragndrop al inventario, este se actualiza a la lista
        inventory.playerItems.Add(GetComponent<UIItem>().item);
    }
}
