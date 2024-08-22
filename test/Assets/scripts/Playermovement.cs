using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class Playermovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    Vector2 orginalPosition;

    private float fcount;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform rightwallcheck;
    [SerializeField] private Transform leftwallcheck;
    [SerializeField] private Transform position;
    [SerializeField] private AudioSource landing;


    
    void Start()
    {
    orginalPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);


    }
    // Update is called once per frame
    void Update()
    {

        

        if (!pausemenu.isPaused)
        if(fcount < 560)
        {
            fcount++;
        }
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


            if (rb.transform.position.y < -20f)
            {
                rb.transform.position = orginalPosition;
            }

            Flip();
        }
        if (!IsGrounded() && fcount > 550)
        {
            landing.Play();
        }
    }


    private void FixedUpdate()
    {
        if (!pausemenu.isPaused)
        {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 1.15f, groundlayer);
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
