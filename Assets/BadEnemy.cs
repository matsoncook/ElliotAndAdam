using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnemy : MonoBehaviour
{

    public int damage = 20;
    public int Health = 50;
    public Rigidbody2D rb;
    public float speed = 2;
    public float GroundRadius;
    private bool IsGrounded;
    public GameObject feetObjectPosition;
    private float countdown = 1.2f;
    public float resetcount = 1.2f;
    public float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1f;
    }

    void Update()
    {
         
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
   

     LayerMask mask = LayerMask.GetMask("Ground");
     var collision = Physics2D.OverlapCircle(feetObjectPosition.transform.position, GroundRadius, mask);
     IsGrounded = collision != null;

        

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Health -= 20;
            if (Health <= 0)
            {
                   gameObject.SetActive(false);
            }
        }
        collision.gameObject.GetComponent<PlayerHealth>().health -= 20;

        if (collision.gameObject.GetComponent<PlayerHealth>().health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.CompareTag("MeleeSword"))
        {
            Health -= 35;
            if (Health <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
