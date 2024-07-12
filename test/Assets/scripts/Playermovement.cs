using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    Vector4 orginalPosition;
    private float count;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform rightwallcheck;
    [SerializeField] private Transform leftwallcheck;
    [SerializeField] private Transform position;
    
    void Start()
    {
    orginalPosition = new Vector4(rb.transform.position.x, rb.transform.position.y);
    count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused)
        {

        
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonDown("Jump") && rightwall())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonDown("Jump") && leftwall())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            
            
            if(rb.transform.position.y < -20f)
            {
                rb.transform.position = orginalPosition;
                count = count + 1;
            }

        Flip();
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }
    
    private bool rightwall()
    {
        return Physics2D.OverlapCircle(rightwallcheck.position, 0.2f, groundlayer);
    }

    private bool leftwall()
    {
        return Physics2D.OverlapCircle(leftwallcheck.position, 0.2f, groundlayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
