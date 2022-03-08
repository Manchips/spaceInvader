using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InvaderManager: MonoBehaviour
{
    public Invader[] prefabs; //Lets just make an array since that looks nicer
    public int rows = 5; //want three rows and I'm not sure about columns yet changed to 5 since thats how many are in space invaders 
    public int columns = 11;

    public Vector3 direction = Vector3.right;

    public float speed = 1f;

    public float attackRate = 2.0f;
    
    public GameObject bullet;
    public Transform shottingOffset;

    
    public void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2f * (columns - 1);
            float height = 2f * (rows - 1);
            Vector3 centering = new Vector3(-width / 2, -height / 2, 0); 
            Vector3 rowPosition = new Vector3(centering.x, centering.y + row * 2f, 0f ); 
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                Vector3 poisition = rowPosition;
                poisition.x += col * 2f;
                invader.transform.position = poisition;
            }
        }
    }

    public void start()
    {
        InvokeRepeating(nameof(attack),attackRate,attackRate);
    }
    private void OnEnable()
    {
        Invader.DeathEvent += onInvaderDeath;
    }

    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;

        Vector3 left = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 right = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (direction == Vector3.right && invader.position.x > right.x)
            {
                goDown();
            } else if (direction == Vector3.left && invader.position.x < left.x)
            {
                goDown();
            }            
        }
    
    }
    
    private void attack()
    {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
    }

    private void goDown()
    {
        direction.x *= -1.0f;
        var position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    private void onInvaderDeath()
    {
        speed += .25f;
    }

    private void OnDisable()
    { 
       Invader.DeathEvent -= onInvaderDeath;
    }
}
