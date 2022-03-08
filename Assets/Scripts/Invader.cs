using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public BoxCollider2D box; 
    //this is gonna be empty for right now but we'll add the animation later, actually wont be empty for the on die degaltes and stuff but I made this early on lol 
    public delegate void DeathDelegate();
    public static event DeathDelegate DeathEvent;

    public delegate void addPoints(int points);

    public static event addPoints PointEvent;

    public float attackRate; 
    // Start is called before the first frame update
    void Start()
    {
        box = this.gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            DeathEvent?.Invoke();

            if (this.gameObject.CompareTag("I1"))
            {
                PointEvent?.Invoke(10);
            }else if (this.gameObject.CompareTag("I2"))
            {
                PointEvent?.Invoke(20);
            }else if (this.gameObject.CompareTag("I3"))
            {
                PointEvent?.Invoke(30);
            }else if (this.gameObject.CompareTag("I3"))
            {
                PointEvent?.Invoke(200);
            }
            
        }
    }
}
