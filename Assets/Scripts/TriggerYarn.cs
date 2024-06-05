using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TriggerYarn : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    PathFinder pathFinder;

    [SerializeField] GameObject YarnUI;
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI pejaText;
    [SerializeField] GameObject pejaHead;

    TriggerPeja peja;
    [SerializeField] string displayedText;

    [SerializeField] AudioSource woolSound;
    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        peja = FindObjectOfType<TriggerPeja>();
    }
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            pathFinder.NewDestinationCoordinates(stopCoordinates);
            pathFinder.NotifyReceivers();
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        woolSound.Play();
        YarnUI.SetActive(true);
        textBox.SetActive(true);
        pejaText.gameObject.SetActive(false);
        pejaHead.gameObject.SetActive(false);
        text.text = displayedText;
        text.gameObject.SetActive(true);
        peja.AddYarn();
    }
}
