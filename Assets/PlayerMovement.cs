using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    private bool IsGrounded;
    public Rigidbody2D rb;
    private float horizontalInput;
    public GameObject feetObjectPosition;
    public float GroundRadius;
    public bool swordCollected;
    private float countdown = 1.2f;
    public float resetcount = 1.2f;
    public bool hasDashCollidedWithPlayer;
    public int meleeAttack;
    private float countdown2 = 0.6f;
    public float resetcount2 = 0.6f;
    public GameObject MeleeAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        LayerMask mask = LayerMask.GetMask("Ground");
        var collision = Physics2D.OverlapCircle(feetObjectPosition.transform.position, GroundRadius, mask);
        IsGrounded = collision != null;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity += new Vector2(0, jumpForce);
        }
        countdown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C) && IsGrounded)
        { 
                if (countdown <= 0 && Input.GetKeyDown(KeyCode.C))
                {
                    countdown = resetcount;
                    rb.velocity += new Vector2(horizontalInput * 0, 5);
                }

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (countdown2 <= 0 && Input.GetMouseButtonDown(0) && horizontalInput > 0)
            {
                countdown2 = resetcount2;
                Instantiate(MeleeAttack, transform.position + transform.right * 2, Quaternion.identity);
            }
            if (countdown2 <= 0 && Input.GetMouseButtonDown(0) && horizontalInput < 0)
            {
                countdown2 = resetcount2;
                Instantiate(MeleeAttack, transform.position + transform.right * -2, Quaternion.identity);
            }

        }
    }
}