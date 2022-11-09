using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public GameObject connectedDoor;
    private GameObject cam;
    private CameraBehavior camScript;
    public bool givesInstruction;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camScript = cam.GetComponent<CameraBehavior>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if ((collision.gameObject.tag == "Player") && (givesInstruction))
        {
            gc.DisplayInstructions("Press [E] to Open");
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
    public Transform UseDoor() {
        camScript.ChangeConstraints(xMin,xMax,yMin,yMax);
        return connectedDoor.transform;
    }
}