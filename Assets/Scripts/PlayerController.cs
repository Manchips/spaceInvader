using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody body;
    public GameObject bullet;
    public Transform shottingOffset;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //gonna get the horizontal keys since its 2d 
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * speed, ForceMode.Force);
        
        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
        
        //checks for space to shot the bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Destroy(shot, 3f);
        }
        
    }
    
    
}
