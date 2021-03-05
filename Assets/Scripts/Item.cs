using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public int cost;
    public string itemname;
    public Text costT;
    public Text itemnameT;
    public Button button;

    private void Start()
    {
        costT.text = cost.ToString();
        itemnameT.text = itemname.ToString();
        

        if (id == 3)
        {
            button.interactable = false;
        }
        

    }

    public void bought()
    {
        if(GetComponentInParent<Shop>().money >= cost)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - cost );
            GetComponentInParent<Shop>().addItem(id);
            button.interactable = false;
        }

    }
}
