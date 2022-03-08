using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public TextMeshProUGUI highScore;

    public int points;

    public int hiScore; 
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        highScore.SetText($"{PlayerPrefs.GetInt("hiScore")}");
    }

    // Update is called once per frame
    void Update()
    {
        if (points > hiScore)
        {
            hiScore = points;
            PlayerPrefs.SetInt("hiScore", hiScore);
        }
    }
    
    private void OnEnable()
    {
        Invader.PointEvent += addPoints;
    }
    private void addPoints(int point)
    {
        points += point;
        if (points < 100)
        {
            score.SetText($"00{points}");
        }else if (points >= 100 && points < 1000)
        {
            score.SetText($"0{points}");
        }
        else
        {
            score.SetText($"{score}");
        }
    }
    private void OnDisable()
    { 
        Invader.PointEvent -= addPoints;
    }
}
