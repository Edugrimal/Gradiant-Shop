using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Text tooltipText;

	void Start () {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false); 
	}
    
    public void GenerateTooltip(Item v_item)
    {
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\nVenta: <b>${2}</b>", v_item.title, v_item.description, v_item.soldPrice);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
