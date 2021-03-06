﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    private bool Mute;
    public Image Muted;
    public static int ScoreValue = 0;
    public float minutes, seconds, milliseconds;
    public Text score;
    public Text timer;
    public void LoadMenuScreen()
    {
        SceneManager.LoadScene(1);    
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(2);
        
    }
    
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(3);
    }
    
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

        public void ToggleAudio()
    {   
        Mute = !Mute;
        AudioListener.pause = Mute; 
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        Mute = false;
        score = GetComponent<Text>();
        timer = GetComponent<Text>();
    }

    public void OnSceneLoaded(Scene scene)
    {
        if (scene.buildIndex == 1)
        {
            Button btn1 = GameObject.FindGameObjectWithTag("LevelOne").GetComponent<Button>();
            btn1.onClick.AddListener(LoadLevelOne);

            Button btn2 = GameObject.FindGameObjectWithTag("LevelTwo").GetComponent<Button>();
            btn2.onClick.AddListener(LoadLevelTwo);

            Button btn3 = GameObject.FindGameObjectWithTag("Exit").GetComponent<Button>();
            btn3.onClick.AddListener(ExitGame);
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            LoadMenuScreen();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            Button btn3 = GameObject.FindGameObjectWithTag("Exit").GetComponent<Button>();
            btn3.onClick.AddListener(ExitGame);

            if (gameObject == GameObject.FindGameObjectWithTag("Score")) // This fixed a nullReference error. There is probs a more efficient way to do this lol
            {
                score.text = "Score: " + ScoreValue;
            }

            if (gameObject == GameObject.FindGameObjectWithTag("Timer"))
            {
                minutes = (int)(Time.timeSinceLevelLoad / 60f);
                seconds = (int)(Time.timeSinceLevelLoad % 60f);
                milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;
                timer.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            Button btn3 = GameObject.FindGameObjectWithTag("Exit").GetComponent<Button>();
            btn3.onClick.AddListener(ExitGame);

        }
    }
}
