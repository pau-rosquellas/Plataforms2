using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System.IO;


public class Item : MonoBehaviour
{
    public int id;
    public int cost;
    public string itemname;
    public Text costT;
    public Text itemnameT;
    public Button button;
    public List<int> idS = new List<int>();
    private void Start()
    {
        loadItemFile();
        costT.text = cost.ToString();
        itemnameT.text = itemname.ToString();
       
        foreach (int i in idS)
        {
            Debug.Log(i);
            if (i == this.id)
            {
                Debug.Log("IGUAL");
                button.interactable = false;
            }
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

    void loadItemFile()
    {
        using (Stream stream = File.Open("save.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            idS = (List<int>)bformatter.Deserialize(stream);
        }
    }


}
