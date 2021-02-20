using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{
    public Transform point;
    public float speed;
    private Vector3 start, end;
    // Start is called before the first frame update
    void Start()
    {
        if (point != null)
        {
            point.parent = null;
            start = transform.position;
            end = point.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (point != null)
        {
            float fixSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, point.position, fixSpeed);
        }
        if (transform.position == point.position)
        {
            point.position = (point.position == start) ? end : start;
        }
    }
}
