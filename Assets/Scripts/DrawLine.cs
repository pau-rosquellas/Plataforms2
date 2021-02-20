using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform a;
    public Transform b;
    
    void OnDrawGizmosSelected()
    {
        if (a != null && b != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(a.position, b.position);
        }
        
    }
}
    
