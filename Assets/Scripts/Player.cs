using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int currentGold;
    public int currentFame;
    public Text moneyText;

    public void Start()
    {
        currentGold = 160;
        currentFame = 1;
        moneyText.text = CurrentGold.ToString();
    }

    public void Update()
    {
        moneyText.text = CurrentGold.ToString();
    }

    public int CurrentGold
    {

        get { return currentGold; }
        set {
            currentGold = value;
            Debug.Log("Tu Gold actual es: " + currentGold);
        }
    }


    [SerializeField]
    public int CurrentFame

    {
        get { return currentFame; }
        set { currentFame = value;

            Debug.Log("your current Fame is" + currentFame);
        }
    }

}
