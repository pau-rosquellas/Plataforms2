using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatAnimations : MonoBehaviour
{
    [SerializeField] private Vector2 finalPosition;
    private Vector2 initialPosition;
    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, finalPosition, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}
