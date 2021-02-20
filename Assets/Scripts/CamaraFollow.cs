using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject pc = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject pc = GameObject.Find("Player(Clone)");

        if (pc != null){

        float posX = pc.transform.position.x;
        float posY = pc.transform.position.y;

        transform.position = new Vector3(posX, 0, transform.position.z);

        }
        
    }
}
