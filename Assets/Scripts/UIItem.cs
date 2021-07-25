using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;
    public bool craftingSlot = false;
    private CraftingSlots craftingSlots;
    public bool craftedItemSlot = false;
    private UINpcSlot v_UINpcSlots;
    public bool npcSlot = false;
    public bool npcSlotOnPointerDown = false;

    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();
        v_UINpcSlots = FindObjectOfType<UINpcSlot>(); //NPC SLOT
        tooltip = FindObjectOfType<Tooltip>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    //Esta funcion se manda a llamar en cualquier momento que un item es puesto en el UI
    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;// Desplegamos el item y su icono
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;//hacemos que el color del item sea trasparente para que no se vea en pantalla
        }
        if (craftingSlot) //Si existe un item en el slot de crafteo
        {
            craftingSlots.UpdateRecipe();
            Debug.Log("TRUE Si existo como craftingSlot");
        }
        if (npcSlot) //Si existe un item en el slot de crafteo, y el item npcItemMatch es true (item que evita loop infinito)
        {
            //npcSlot = false;
            Debug.Log("Entre a npcSlot");
            v_UINpcSlots.UpdateRecipe();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null && !craftedItemSlot)
            {
                Debug.Log("Entre 1 al OnPointerClick");

            }
            else if (selectedItem.item == null && npcSlotOnPointerDown) // validamos que haya entrado en un slot de tipo NPC
            {
                if (npcSlot) //NPC slot es el boleano que indica true si se presionó en el slot tipo NPC. Después se usa para validar si el item seleccionado es igual al item que quiere NPC
                {
                    npcSlotOnPointerDown = false;
                    Debug.Log("Entre 3 al OnPointerClick");
                    selectedItem.UpdateItem(this.item); // Como no es el item, le dejo el item al cursor
                    UpdateItem(null);                   // Borro el item del slot porque no era el item del NPC  
                } else // Como ya se que es false el slot, significa que ya encontré el item que quiere el npc. Aqui borro el item del seleccionado y del slot npc
                {
                    npcSlotOnPointerDown = false;
                    Debug.Log("Entre 2 al OnPointerClick");
                    selectedItem.UpdateItem(null); // Borro el item del cursor porque es consumido por el NPC
                    UpdateItem(null);              // Borro el item del slot porque ya fue completado el request  
                }
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Nuevo OnPointerDown 1");

        if (this.item != null)
        {
            if (selectedItem.item != null && !craftedItemSlot)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else if (selectedItem.item == null)
            {
                Debug.Log("Nuevo OnPointerDown 2");
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
                if (craftedItemSlot)
                {
                    Debug.Log("Nuevo OnPointerDown 3");
                    Debug.Log("Entre a CollectCraftResult de craftedItemSlot");
                    GetComponent<UICraftResult>().CollectCraftResult();
                }
                /*
                if (npcSlotOnPointerDown) // Se agregó para saber si existe un item correcto para el NPC 
                {
                    npcSlotOnPointerDown = false;
                    Debug.Log("Entre a OnPointerDown a CollectCraftResult de npcSlot");
                    v_UINpcSlots.CollectCraftResult();
                }
                */
            }
        }
        else if (selectedItem.item != null && !craftedItemSlot)
        {
            Debug.Log("Nuevo OnPointerDown 4");
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
