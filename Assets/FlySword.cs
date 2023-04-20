using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFly : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    public GameObject Player;
    private bool swordCollected = false;
    void Start()
    {
        GetComponent<Rigidbody2D>(); rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        swordCollected = Player.GetComponent<PlayerMovement>().swordCollected;

        if (swordCollected == (true))
        {
            rb.velocity = transform.right * 5 * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
