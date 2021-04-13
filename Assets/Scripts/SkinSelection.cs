using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SceneManagement;

public class SkinSelection : MonoBehaviour
{
    public List<int> idShop;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button chooseButton;
    private int currentHat;

    [SerializeField] private Sprite btnBlock;
    [SerializeField] private Sprite btnFree;

    private static int choose;

    private void Awake()
    {
        loadItemFile();
        SelectHat(0);
    }
    
    private void SelectHat(int index)
    {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount - 1);

        Debug.Log(index);

        choose = Int32.Parse(transform.GetChild(index).gameObject.name);

        if (idShop.Contains(Int32.Parse(transform.GetChild(index).gameObject.name))) 
        {
            Debug.Log("Comprada");
            chooseButton.image.sprite = btnFree;
            chooseButton.interactable = true;
        }
        else
        {
            Debug.Log("NO Comprada");
            chooseButton.image.sprite = btnBlock;
            chooseButton.interactable = false;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void ChangeHat(int change)
    {
        currentHat += change;
        SelectHat(currentHat);
    }


    void loadItemFile()
    {
        using (Stream stream = File.Open("save.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            idShop = (List<int>)bformatter.Deserialize(stream);
        }
    }

    public void chooseHat()
    {
        PlayerPrefs.SetInt("skinChoosen", choose);
        SceneManager.LoadScene("MainMenu");
    }

}
