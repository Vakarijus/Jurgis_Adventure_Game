using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OpenChest : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    Animator animator;
    [SerializeField] Animator honeyAnimator;
    [SerializeField] GameObject honeyJar;
    PathFinder pathFinder;

    [SerializeField] GameObject honeyUI;
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI pejaText;
    [SerializeField] GameObject pejaHead;

    AudioSource openAudio;

    bool honey = false;
    public bool Honey{get{return honey;}}
    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        animator = GetComponent<Animator>();
        openAudio = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            pathFinder.NewDestinationCoordinates(stopCoordinates);
            pathFinder.NotifyReceivers();
            StartCoroutine(Animation());
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.5f);
        openAudio.Play();
        animator.SetBool("Open", true);
        honeyAnimator.SetBool("Open", true);
        honey = true;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(honeyJar);
        honeyUI.SetActive(true);
        textBox.SetActive(true);
        pejaText.gameObject.SetActive(false);
        pejaHead.gameObject.SetActive(false);
        text.text = "Skrynioje radai medaus! Ji gali rasti kuprineje";
        text.gameObject.SetActive(true);
    }
}
