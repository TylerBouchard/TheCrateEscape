using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public bool inCrate;
    public Transform location;
    private bool touchingPlayer = false;
    private bool beingHeld = false;
    public int unlocksDoor;
    public AudioClip pickupSound;
    void Start()
    {
        if (inCrate) {
            gameObject.SetActive(false);
        }
        transform.position = location.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();
        if (Input.GetKeyDown(KeyCode.Q) && touchingPlayer && !beingHeld) {
            location = GameObject.Find("StickGuy").transform;
            beingHeld = true;
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && beingHeld)
        {
            location = gameObject.transform;
            beingHeld = false;
        }
        if (touchingPlayer && beingHeld)
        {
            gc.HideInstructions();
        }
        else if (touchingPlayer) {
            gc.DisplayInstructions("Press [Q] to Pickup");
        } 
        transform.position = location.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = false;
            gc.HideInstructions();
        }
    }
    public void ObjVisable(bool choice) {
        gameObject.SetActive(choice);
    }
    public int GetKeyNumber() {
        return unlocksDoor;
    }
    public void RemoveItem() {
        gameObject.SetActive(false);
    }
}
