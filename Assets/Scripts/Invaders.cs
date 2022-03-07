using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs; //Lets just make an array since that looks nicer
    public int rows = 5; //want three rows and I'm not sure about columns yet 
    public int columns = 11;

    public Vector3 direction = Vector3.right;

    public float speed = 5f;
    
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

    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
        
        
    }

    private void GoDown()
    {
        direction.x *= -1f;

        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }
}
