using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollinPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    [SerializeField] private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(rb.velocity.y > 0f)
        {
            if(currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y * 0.5f);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y * 0.5f);
            }
        }
        else
        {
            if(currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        if(rb.transform.position.y < -20f)
        {
            rb.transform.position = originalPosition;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}