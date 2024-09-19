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
    public static Playermovement Instance;
    void Awake()
    {

    }
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    Vector2 orginalPosition;
    public Action onDeath;
    private float fcount;


    [SerializeField] public Rigidbody2D rb;    
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform groundcheckup;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform rightwallcheck;
    [SerializeField] private Transform leftwallcheck;
    [SerializeField] private Transform position;
    [SerializeField] private AudioSource landing;
    public GameObject Player;


    
    void Start()
    {
    orginalPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
    gameObject.SetActive(false);

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


            if (rb.transform.position.y < -20.3f)
            {
                rb.transform.position = orginalPosition;
                onDeath?.Invoke();
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
        return Physics2D.OverlapArea(groundcheck.position, groundcheckup.position, groundlayer);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rightwallcheck.transform.position, 0.2f);
        Gizmos.DrawWireSphere(leftwallcheck.transform.position, 0.2f);


    }

    public void SetPlayerPos(Vector3 newpos)
    {
        rb.velocity = Vector2.zero;
        transform.position = newpos;
    }


}
