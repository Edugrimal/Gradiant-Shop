using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public event Action<int> onCurrentGoldChanged;
    public Player v_player;
    public Npc v_Npc;

    // Start is called before the first frame update
    void Start()
    {
        //SellPotionToNpc();
        v_player = FindObjectOfType<Player>(); // obtenemos el jugador actual
        v_Npc = FindObjectOfType<Npc>(); // obtenemos el jugador actual
    }

    public void SellPotionToNpc()
    {
        if (v_Npc.requestInProgress) //Si el request aun no ha sido completado
        {
            Inventory inventory = FindObjectOfType<Inventory>(); //Mando llamar mis variables de inventario para modificarlas
            //SpendGold(v_Npc.requestedItem.soldPrice); 
            AddGold(v_Npc.requestedItem.soldPrice); 
            inventory.RemoveItem(v_Npc.requestedItem.id); // Se manda como parametro el ID del Item del NPC y el inventorio se encarga de quitarlo de ahi
            v_Npc.requestInProgress = false;
            Debug.Log("El NPC compro " + v_Npc.requestedItem.description + " a la cantidad de "+ v_Npc.requestedItem.soldPrice + " Gold");

        }
        else
        {
            Debug.Log("Ya se completó la transacción.");
        }

    }

    //Funcion que quitará dinero directamente del Player, revisando primero si el Player puede comprar
    public bool SpendGold(int amount)
    {
        if (HaveEnoughGold(amount))
        {
            v_player.CurrentGold -= amount;
            onCurrentGoldChanged?.Invoke(v_player.currentGold);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Funcion que se manda llamar para verificar si hay suficiente dinero del jugador antes de comprar el valor de un item
    public bool HaveEnoughGold(int amount)
    {
        return v_player.currentGold >= amount; // Si el currentGold del jugador es mayor o igual al valor del item, regresa True.
    }

    public void AddGold(int amount)
    {
        v_player.CurrentGold += amount;
        onCurrentGoldChanged?.Invoke(v_player.currentGold);
    }
}

