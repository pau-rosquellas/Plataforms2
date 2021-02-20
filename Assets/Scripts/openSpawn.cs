using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSpawn : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update() {
        StartCoroutine(waitOpen());
        
     }

     
    private IEnumerator waitOpen()
    {
        yield return new WaitForSeconds (10);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }
}
