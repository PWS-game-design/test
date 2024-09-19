using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
    
{
        public Action onDeath;
    public static PlayerManager Instance;
    public GameObject Player;
    [SerializeField] public Rigidbody2D rb;

    void Awake()
    {
                if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void SetPlayerPos(Vector3 newpos)
    {
        rb.velocity = Vector2.zero;
        transform.position = newpos;
    }
}
