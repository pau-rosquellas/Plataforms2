using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemy;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.velocity = new Vector2(speed, enemy.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "col")
        {
            speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }

}
