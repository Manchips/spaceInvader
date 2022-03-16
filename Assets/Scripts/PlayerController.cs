using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    PlayerController : MonoBehaviour
{
    private float speed = 7f;
    //private Rigidbody body holdover from when I was using the axis 
    public GameObject bullet;
    public Transform shottingOffset;

    public delegate void playerDeathDelegate();

    public static event playerDeathDelegate PlayerDeathEvent;
    
    // Update is called once per frame
    void Update()
    {
        //gonna get the horizontal keys since its 2d actually stratch that hated movement with the axis so 
        //were just gonna use the getkey for if the button is held down or not 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * this.speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        
        //checks for space to shot the bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Destroy(shot, 3f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            PlayerDeathEvent?.Invoke();
        }
    }
}
