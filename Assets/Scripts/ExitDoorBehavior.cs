using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehavior : MonoBehaviour
{
    bool touchingPlayer = false;
    private GameObject guy;
    private PlayerBehavior guyScript;
    void Start()
    {
        guy = GameObject.Find("StickGuy");
        guyScript = guy.GetComponent<PlayerBehavior>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer) {
            guyScript.ChangeCanMove(false);
            GameController gc = FindObjectOfType<GameController>();
            gc.DisplayInstructions("YOU FOUND THE EXIT! [P] to Play Again");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if ((collision.gameObject.tag == "Player"))
        {
            gc.DisplayInstructions("Press [E] to WIN!");
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            gc.HideInstructions();
            touchingPlayer = false;
        }
    }
}
