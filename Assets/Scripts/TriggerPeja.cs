using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TriggerPeja : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    //Animator animator;
    PathFinder pathFinder;

    [SerializeField] Animator signAnimator;
    [SerializeField] GameObject hey;

    [SerializeField] GameObject textBox;
    [SerializeField] GameObject pejaHead;
    [SerializeField] TextMeshProUGUI dialogue;
    [SerializeField] TextMeshProUGUI interactableText;

    [SerializeField] string taskText;
    [SerializeField] string endText;
    int yarn = 0;

    AudioSource pejaAudio;

    bool flyCaught = false;
    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        pejaAudio = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();
    }
    public void Caught()
    {
        flyCaught = true;
    }
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            pathFinder.NewDestinationCoordinates(stopCoordinates);
            pathFinder.NotifyReceivers();
            if(flyCaught == true || yarn == 3)
            {
                Debug.Log("You won!");
                signAnimator.SetBool("LevelOver", true);
                dialogue.text = endText;
            }
            else
            {
                dialogue.text = taskText;
            }
            pejaAudio.Play();
            textBox.SetActive(true);
            pejaHead.SetActive(true);
            interactableText.gameObject.SetActive(false);
            dialogue.gameObject.SetActive(true);
            Destroy(hey);
        }
    }
    public void AddYarn()
    {
        yarn++;
        Debug.Log(yarn);
    }
}
