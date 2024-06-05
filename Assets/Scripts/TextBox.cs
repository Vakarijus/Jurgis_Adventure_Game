using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] GameObject pejaHead;
    [SerializeField] TextMeshProUGUI pejaText;
    [SerializeField] TextMeshProUGUI interactableText;

    public void exitTextBox()
    {
        this.gameObject.SetActive(false);
        pejaHead.SetActive(false);
        pejaText.gameObject.SetActive(false);
        interactableText.gameObject.SetActive(false);
    } 
}