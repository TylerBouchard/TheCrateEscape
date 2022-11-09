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
        if (Input.GetKeyDown(KeyCode.Q) && touchingPlayer && !beingHeld) {
            location = GameObject.Find("StickGuy").transform;
            beingHeld = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && beingHeld)
        {
            location = gameObject.transform;
            beingHeld = false;
        }
        transform.position = location.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            touchingPlayer = true;
            print("touching player");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = false;
            print("not touching player");
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
