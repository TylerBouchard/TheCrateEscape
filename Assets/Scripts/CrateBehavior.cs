using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    Rigidbody2D crateVelocity;
    public float deceleration = 0.01f;
    public GameObject ObjectInCrate;
    public bool hasObject = false;
    private bool nearPlayer = false;
    private float StartX;
    private float StartY;
    public int roomNumber;
    void Start()
    {
        crateVelocity = GetComponent<Rigidbody2D>();
        StartX = transform.position.x;
        StartY = transform.position.y;
    }
    void Update()
    {
        Vector2 vel = crateVelocity.velocity;
        if (vel.x < 0)
        {
            vel.x = vel.x + deceleration;
            if (vel.x > 0) { vel.x = 0; }
            crateVelocity.velocity = vel;
        }
        else if (vel.x > 0)
        {
            vel.x = vel.x - deceleration;
            if (vel.x < 0) { vel.x = 0; }
            crateVelocity.velocity = vel;
        }
        if ((Input.GetKeyDown("e"))&&(nearPlayer)) {
            BreakCrate();
        }
    }
    public void BreakCrate() {
        if (hasObject) {

            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    public void ResetCrate(int room) {
        if (room == roomNumber) {
            print("reseting");
            Vector3 CratePos = transform.position;
            CratePos.x = StartX;
            CratePos.y = StartY;
            transform.position = CratePos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            gc.DisplayInstructions("Press [Q] to pull crates");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            gc.HideInstructions();
        }
    }
}