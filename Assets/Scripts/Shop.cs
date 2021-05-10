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

    public List<int> idShop;

    public void Start()
    {
      money = PlayerPrefs.GetInt("Money", 0);
      moneyText.text = money.ToString();
      loadItemFile();
    }

    
    public void addItem(int id)
    {
        moneyText.text = PlayerPrefs.GetInt("Money", 0).ToString();
        idShop.Add(id);
        saveItemFile();
    }

    void saveItemFile()
    {
        FileStream fs = new FileStream("save5.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, idShop);
        fs.Close();
    }

    void loadItemFile()
    {
        
        using (Stream stream = File.Open("save5.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            idShop = (List<int>)bformatter.Deserialize(stream);
        }
    }

    public List<int> getIdShop()
    {
        return idShop;
    }

    public void resetList()
    {
        foreach (int i in idShop)
        {
            idShop.RemoveAt(i);
        }

        FileStream fs = new FileStream("save5.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, idShop);
        fs.Close();
    }

    
}
