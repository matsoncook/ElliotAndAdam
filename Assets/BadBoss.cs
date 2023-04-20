using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadBoss : BadEnemy
{

    public int Health = 1000;
    public float speed = 9;
    public float jumpForce = 15;
    public float GroundRadius;
    private bool IsGrounded;
    public Rigidbody2D rb;
    public GameObject feetObjectPosition;
    private float countdown = 8.5f;
    public float resetcount = 8.5f;
    private float countdown2 = 4f;
    public float resetcount2 = 4f;
    private float countdown3 = 1.5f;
    public float resetcount3 = 1.5f;
    private float countdown4 = 4f;
    public float resetcount4 = 4f;
    public int damage = 45;
    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1;
    }

    
    void Update()
    {

        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
      
        LayerMask mask = LayerMask.GetMask("Ground");
        var collision = Physics2D.OverlapCircle(feetObjectPosition.transform.position, GroundRadius, mask);
        IsGrounded = collision != null;
        if (IsGrounded) 
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = resetcount;
                rb.velocity += new Vector2(0, jumpForce);
            } 
        }
        if (IsGrounded)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = resetcount;
                Instantiate(Attack1, transform.position + transform.right * 2,Quaternion.identity);
                Instantiate(Attack1, transform.position + transform.right * -2, Quaternion.identity);
            }
        }
        if (IsGrounded)
        {
            countdown2 -= Time.deltaTime;
            if (countdown2 <= 0)
            {
                countdown2 = resetcount2;
                Instantiate(Attack2, transform.position + transform.right * -2, Quaternion.identity);
                Instantiate(Attack2, transform.position + transform.right * 2, Quaternion.identity);
            }
        }
        if (IsGrounded)
        {
            countdown3 -= Time.deltaTime;
            if (countdown3 <= 0)
            {
                countdown3 = resetcount3;
                Instantiate(Attack3, transform.position + transform.right * -2, Quaternion.identity);
                Instantiate(Attack3, transform.position + transform.right * 2, Quaternion.identity);
            }
        }
        if (IsGrounded)
        {
            countdown4 -= Time.deltaTime;
            if (countdown4 <= 0)
            {
                countdown4 = resetcount4;
                direction *= -1;
                
            }
        }
    }

}
