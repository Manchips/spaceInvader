using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    //This is easy just make it so it goes up whenever we destory an alien 
    public TextMeshProUGUI playerScore;
    
    //This only gets increased once the player dies, right now we don't have lives
    //Set the old hiScore to be this if its higher I don't know how to set it to be 
    //That way on another boot up but I should ask whenever I get the chance 
    public TextMeshProUGUI hiScore;

    public int points; //Count will be used like before its zero and we add stuff to it 

    public int totalPoints; 

    public bool countGreater; 
    // Start is called before the first frame update
    void Start()
    {
        totalPoints = 0;
        countGreater = false;
    }
    //I want to make sure that the totalPoints are either greater then 100 or 1000 probably set a string to be 00/0

    public bool check()
    {
        if (totalPoints < 100)
        {
            return false; 
        }
        return true;
    }
}
