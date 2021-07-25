using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerShop : MonoBehaviour
{

    //Timer del dia
    public float dayStart;
    public float dayEnd;
    public Text dayTimer;


    //Timer del cliente
    public Text clientTimer;
    public float clientStart;
    public float clientEnd;
    public GameObject menuContainer;





    bool timerActive = false;// este debe de empezar en false

    int timerToSeconds(float timer)
    {
        //A esta funcion le mandas una variable tipo float (como el timer) y te lo regresa como un int ()
        return Mathf.FloorToInt(timer);
    }


    void Start()
    {
        dayTimer.text = dayStart.ToString("F2");
        dayEnd = 10; // 480 termina el dia;
                     // clientTimer.text = clientStart.ToString("F2"); // este es el timer del cliente, que aun no esta establezido
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {//Si el tiempo esta corriendo
            dayStart += Time.deltaTime;
            dayTimer.text = dayStart.ToString("F2");
            if (timerToSeconds(dayStart) >= timerToSeconds(dayEnd))//Si el dia de tiempo es mayor al limite de tiempo
            {
                timerActive = !timerActive;
                menuContainer.SetActive(true);
            }
        }

    }

    public void timerButton()
    {
        timerActive = !timerActive;
    }

}
