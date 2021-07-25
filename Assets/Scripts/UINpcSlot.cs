using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UINpcSlot : MonoBehaviour
{
    public SlotPanel slotPanel;
    public Inventory inventory;
    public Item itemToSellToNPC;
    public Shop v_shop;

    public Npc v_npc;
    private List<UIItem> uiItems = new List<UIItem>();
    public UIItem sellToNPCSlot;
    public void CollectCraftResult()
    {
        //slotPanel.RemoveItem(GetComponent<UIItem>().item); // Se quita el item del slot visualmente
        slotPanel.EmptyAllSlots(); // Se manda llamar el eliminado de la lista del craftingtable cuando se dragndrop el nuevo item combinado
        //inventory.playerItems.Remove(GetComponent<UIItem>().item); // se quita el item de la lista de inventario del Player
        Debug.Log("Vend� el item successfully");
        v_shop.SellPotionToNpc(); //Agrega dinero restado al player EJEMPLO
    }

    public void UpdateRecipe( )
    {
        int[] itemTable = new int[uiItems.Count];
        Debug.Log("El conteo es de : " + uiItems.Count);
        for (int i = 0; i < uiItems.Count; i++)
        {
            if (uiItems[i].item != null)
            {
                if (v_npc.requestedItem.id == uiItems[i].item.id) // El ID de la variable item requestedItem del NPC es comparado con el ID que tenga el slotNpc
                {
                    itemToSellToNPC = uiItems[i].item;
                    Debug.Log("Entre a UpdateRecipe dentro del loop: " + i);
                    CollectCraftResult(); //quitamos el item del slot de sellToNPC
                    uiItems[i].npcSlotOnPointerDown = true;
                    uiItems[i].npcSlot = false;
                    UpdateCraftingResultSlot(itemToSellToNPC);
                }
                else
                {
                    Debug.Log("No es el item que quiero");
                    itemToSellToNPC = uiItems[i].item;
                    //CollectCraftResult(false); //quitamos el item del slot de sellToNPC
                    uiItems[i].npcSlotOnPointerDown = true;
                    uiItems[i].npcSlot = true;
                }
            }

        }
    }
    void UpdateCraftingResultSlot(Item itemToSellToNPC)
    {
        sellToNPCSlot.UpdateItem(itemToSellToNPC);
        Debug.Log("Entre a UpdateCraftingResultSlot");
    }
    private void Start()
    {
        v_shop = FindObjectOfType<Shop>();
        slotPanel = FindObjectOfType<SlotPanel>();
        inventory = FindObjectOfType<Inventory>();
        uiItems = slotPanel.uiItems;
        uiItems.ForEach(i => i.npcSlot = true);
        v_npc = FindObjectOfType<Npc>(); //Obtiene el NPC que se creo en escena EJEMPLO, cuando haya m�s NPC puede que no funcione
    }

}
