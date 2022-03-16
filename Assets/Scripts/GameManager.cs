using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene CurrentScene; 
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScene.name == "Credits")
        {
            Invoke("back2Main",5f);
        }
        CurrentScene = SceneManager.GetActiveScene();
    }

    public void LoadScene(string mainGame)
    {
        SceneManager.LoadScene(mainGame);
    }

    public void back2Main()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void OnEnable()
    {
        PlayerController.PlayerDeathEvent += onPlayerDeath;
    }

    public void onPlayerDeath()
    {
        SceneManager.LoadScene("Credits");
    }

    private void OnDisable()
    {
        PlayerController.PlayerDeathEvent -= onPlayerDeath;
    }
    
}
