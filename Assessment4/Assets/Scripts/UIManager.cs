using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    private bool Mute;
    public Image Muted;

    public void LoadMenuScreen()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            SceneManager.LoadScene(1);
        }
            
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadMenuScreen();
        }

        
        
    }
}
