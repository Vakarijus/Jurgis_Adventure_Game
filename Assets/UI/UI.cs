using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    bool bagOpen = false;
    [SerializeField] GameObject inventory;
    AudioSource bagSound;
    void Start()
    {
        bagSound = GetComponent<AudioSource>();
    }
    public void OpenBag()
    {
        bagSound.Play();
        inventory.SetActive(!bagOpen);
        bagOpen = !bagOpen;
    }
}
