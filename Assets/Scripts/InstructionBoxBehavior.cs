using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBoxBehavior : MonoBehaviour
{
    public Transform cam;
    public float yPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos = cam.position;
        pos.y += yPos;
        pos.z += 5;
        transform.position = pos;
    }
}
