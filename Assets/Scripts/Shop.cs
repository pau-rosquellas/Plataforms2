using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Shop : MonoBehaviour
{
    public int money = 0;
    public Text moneyText;

    public List<int> idShop = new List<int>();

    public void Start()
    {

      PlayerPrefs.SetInt("Money", 100);
      money = PlayerPrefs.GetInt("Money", 0);
      moneyText.text = money.ToString();
      loadItemFile();

        foreach (int i in idShop)
       {
             Debug.Log(i);
        }
       

    }

    
    public void addItem(int id)
    {
        moneyText.text = PlayerPrefs.GetInt("Money", 0).ToString();
        idShop.Add(id);
        saveItemFile();
    }

    void saveItemFile()
    {
        FileStream fs = new FileStream("save.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, idShop);
        fs.Close();
    }

    void loadItemFile()
    {
        using (Stream stream = File.Open("save.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            idShop = (List<int>)bformatter.Deserialize(stream);
        }
    }

}
