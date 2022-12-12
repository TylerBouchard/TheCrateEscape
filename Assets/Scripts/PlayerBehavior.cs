using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0;
    public float maxSpeed = 7;
    public float acceleration = 0.05f;
    public float midAirAcceleration = 0.025f;
    public float deceleration = 0.05f;
    public float midAirDeceleration = 0.005f;
    public float jumpPower = 15;
    public AudioClip jumpSound;

    private GameObject door;
    private DoorBehavior doorScript;
    private GameObject resetButton;
    private ResetButtonBehavior resetBehaviorScript;
    private bool touchingReset = false;
    private bool grounded = false;
    private bool touchingDoor = false;
    private bool canMove = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        door = GameObject.FindGameObjectWithTag("Door");
        doorScript = door.GetComponent<DoorBehavior>();
        resetButton = GameObject.FindGameObjectWithTag("ResetButton");
        resetBehaviorScript = resetButton.GetComponent<ResetButtonBehavior>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (touchingDoor))
        {

            Transform doorLocation = doorScript.UseDoor();
            Vector3 playerPos = doorLocation.position;
            transform.position = playerPos;
        }
        if ((Input.GetKeyDown(KeyCode.R)) && (touchingReset))
        {
            print("R");
            resetBehaviorScript.ResetCrates();
        }
    }
    void FixedUpdate()
    {
        if (canMove) {
            PlayerMovement();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Solid"){
            grounded = true;
        }
        if (collision.gameObject.tag == "Crate")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Door")
        {
            touchingDoor = true;
            door = collision.gameObject;
            doorScript = door.GetComponent<DoorBehavior>();
        }
       if (collision.gameObject.tag == "ResetButton")
        {
            touchingReset = true;
            resetButton = collision.gameObject;
            print(resetButton);
            resetBehaviorScript = resetButton.GetComponent<ResetButtonBehavior>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Solid") || (collision.gameObject.tag == "Crate"))
        {
            grounded = false;
        }
        if (collision.gameObject.tag == "Door")
        {
            touchingDoor = false;
        }
        if (collision.gameObject.tag == "ResetButton")
        {
            touchingReset = false;

        }
    }
    private void Jump(float height)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, height);
    }
    private void PlayerMovement() {
        if (Input.GetKey("d") && (speed < maxSpeed))
        {
            if (grounded)
            {
                speed += acceleration;
            }
            else
            {
                speed += midAirAcceleration;
            }
        }
        else if (Input.GetKey("a") && (speed > -maxSpeed))
        {
            if (grounded)
            {
                speed -= acceleration;
            }
            else
            {
                speed -= midAirAcceleration;
            }
        }
        else
        {
            if (speed > deceleration)
            {
                if (grounded)
                {
                    speed -= deceleration;
                }
                else
                {
                    speed -= midAirDeceleration;
                }
            }
            else if (speed < -deceleration)
            {
                if (grounded)
                {
                    speed += deceleration;
                }
                else
                {
                    speed += midAirDeceleration;
                }
            }
            else
            {
                speed = 0;
            }
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump(jumpPower);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
        Vector2 vel = rb.velocity;
        vel.x = speed;
        rb.velocity = vel;
    }
    public void ChangeCanMove(bool answer) {
        canMove = answer;
    }
}
