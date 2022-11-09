using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideDoorBehavior : MonoBehaviour
{
    public int doorNumber;
    public float slideSpeed = 0.1f;
   
    private bool nearKey = false;
    private bool nearPlayer = false;

    private GameObject key;
    private ItemBehavior keyScript;
    private float doorHeight = 0;
    void Start()
    {

    }
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();
        if (canOpenDoor())
        {
            gc.DisplayInstructions("Press [E] to open");
        }
        else if (nearKey && nearPlayer)
        {
            gc.DisplayInstructions("This key dosen't work");
        }
        else if (nearPlayer)
        {
            gc.DisplayInstructions("A key is required to unlock");
        }
        else {
           // gc.HideInstructions();
        }
        if (Input.GetKeyDown(KeyCode.E) && canOpenDoor())
        {
            OpenDoor();
            keyScript.RemoveItem();
        }
    }
    public void OpenDoor() {
        Vector3 doorPos = transform.position;
        while (doorHeight < 2.1f)
        {
            doorPos.y = doorPos.y + slideSpeed;
            doorHeight += slideSpeed;
            transform.position = doorPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nearPlayer = true;
        }
        if (collision.gameObject.tag == "Key")
        {
            nearKey = true;
            key = collision.gameObject;
            keyScript = key.GetComponent<ItemBehavior>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.HideInstructions();
            nearPlayer = false;
        }
        if (collision.gameObject.tag == "Key")
        {
            print("touched");
            nearKey = false;
        }
    }
    private bool canOpenDoor() {
        if (nearKey && nearPlayer && (keyScript.GetKeyNumber() == doorNumber)) {
            return true;
        }
        return false;
    }
}
