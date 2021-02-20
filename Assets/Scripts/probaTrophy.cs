using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class probaTrophy : MonoBehaviour
{
        
        public Text proba2;

    // Start is called before the first frame update


    void Start()
    {
        
        proba2.text = PlayerPrefs.GetInt("TrophysTotal", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
