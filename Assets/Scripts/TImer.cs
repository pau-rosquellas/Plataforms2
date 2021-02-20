using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{

    public Text txt;
    public Image imagen;
    public float time;
    private float currentTime;
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = time;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
            imagen.fillAmount = currentTime / time;
            txt.text = currentTime.ToString();
            if (currentTime == 0)
            {
                canvas.SetActive(false);
            }
            
        }
    }
}
