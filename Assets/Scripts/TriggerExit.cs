using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TriggerExit : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    //Animator animator;
    PathFinder pathFinder;

    public Animator transition;
    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
    }
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            pathFinder.NewDestinationCoordinates(stopCoordinates);
            pathFinder.NotifyReceivers();
            Invoke("StartTransition", 1f);
        }
    }
    void StartTransition()
    {
        transition.SetTrigger("Start");
        Invoke("LoadNextLevel", 1f);
    }
    void LoadNextLevel()
    {
        int NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(NextSceneIndex);
    }
}
