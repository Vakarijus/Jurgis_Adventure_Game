using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TriggerSign : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    PathFinder pathFinder;
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI interactableText;
    [SerializeField] TextMeshProUGUI pejaText;
    [SerializeField] GameObject pejaHead;

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
            textBox.SetActive(true);
            pejaText.gameObject.SetActive(false);
            pejaHead.gameObject.SetActive(false);
            interactableText.text = "Kelias uzdarytas!";
            interactableText.gameObject.SetActive(true);
        }
    }
}
