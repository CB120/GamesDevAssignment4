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

    public void LoadFirstLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            SceneManager.LoadScene(1);
        }
            
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadFirstLevel();
        }

        
    }
}
