using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public Animator transition;
    AudioSource woodSound;
    void Awake()
    {
        woodSound = GetComponent<AudioSource>();
    }
    public void Play()
    {
        woodSound.Play();
        transition.SetTrigger("Start");
        Invoke("LoadNextLevel", 1f);
    }
    void LoadNextLevel()
    {
        int NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(NextSceneIndex);
    }
    public void StartOver()
    {
        woodSound.Play();
        transition.SetTrigger("Start");
        Invoke("LoadFirstLevel", 1f);
    }
    void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        woodSound.Play();
        //If The Game is Built we quit the application
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        //if running in editor, we stop playing the scene
        #if UNITY_EDITOR
            Debug.Log("You have quit the game");
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
