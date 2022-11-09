using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonBehavior : MonoBehaviour
{
    private GameObject player;
    private PlayerBehavior playerScript;
    private GameObject slideDoor;
    private SlideDoorBehavior slideDoorScript;
    void Start()
    {
        player = GameObject.Find("StickGuy");
        playerScript = player.GetComponent<PlayerBehavior>();
        slideDoor = GameObject.Find("SlideDoor0");
        slideDoorScript = slideDoor.GetComponent<SlideDoorBehavior>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            print("clicked");
            playerScript.ChangeCanMove(true);
            slideDoorScript.OpenDoor();
            gameObject.SetActive(false);
        }
    }
}
