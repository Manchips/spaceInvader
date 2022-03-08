using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricades : MonoBehaviour
{
    public BoxCollider2D box;

    public int hitsTobreak;
    // Start is called before the first frame update
    void Start()
    {
        box = this.gameObject.AddComponent<BoxCollider2D>();
        hitsTobreak = 4; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hitsTobreak == 0)
        {
            Destroy(gameObject);
        }
        
        hitsTobreak--;
    }
}
