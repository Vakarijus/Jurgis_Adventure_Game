using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TriggerFly : MonoBehaviour
{
    [SerializeField] Vector2Int stopCoordinates = new Vector2Int();
    PathFinder pathFinder;

    [SerializeField] Animator flyAnimator;
    Animator animator;

    [SerializeField] bool rightTree;

    OpenChest openChest;
    MeshRenderer meshRenderer;
    TriggerPeja peja;
    PlayerMover playerMover;
    bool flyCaught = false;
    [SerializeField] GameObject honeyTree;

    [SerializeField] GameObject flyUI;

    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI interactableText;
    [SerializeField] TextMeshProUGUI pejaText;
    [SerializeField] GameObject pejaHead;
    bool walking;

    [SerializeField] AudioSource bushSound;

    void Awake()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        animator = GetComponent<Animator>();
        openChest = FindObjectOfType<OpenChest>();
        meshRenderer = GetComponent<MeshRenderer>();
        peja = FindObjectOfType<TriggerPeja>();
        playerMover = FindObjectOfType<PlayerMover>();
        //bushSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        walking = playerMover.Walking();
        if(flyAnimator.GetBool("FlyLeft") == !rightTree)
        {
            animator.SetBool("Change", false);
        }
        else if(flyAnimator.GetBool("FlyRight") == !rightTree)
        {
            animator.SetBool("Change", true);
        }
    }
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            pathFinder.NewDestinationCoordinates(stopCoordinates);
            pathFinder.NotifyReceivers();
            bushSound.Play();
            if(openChest.Honey == true)
            {
                Debug.Log("honey poared");
                meshRenderer.enabled = false;
                honeyTree.SetActive(true);
                if(flyAnimator.GetBool("FlyRight") == rightTree && !flyCaught)
                {
                    Debug.Log("Fly Caught!");
                    peja.Caught();
                    flyCaught = true;
                    flyUI.SetActive(true);
                    textBox.SetActive(true);
                    pejaText.gameObject.SetActive(false);
                    pejaHead.gameObject.SetActive(false);
                    interactableText.text = "Pagavai muse! Ja gali rasti kuprineje";
                    interactableText.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Nothing happened");
            }
            if(meshRenderer.enabled == true)
            {
                flyAnimator.SetBool("FlyLeft", rightTree);
                flyAnimator.SetBool("FlyRight", !rightTree);
            }
        }
    }
}
