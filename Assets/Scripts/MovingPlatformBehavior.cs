using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool movingUp = false;
    private Transform startPos;
    void Start()
    {
        startPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 platformPos = startPos.position;
        float leftCon = platformPos.x;
        float rightCon = platformPos.x + distance;
        if (platformPos.x > rightCon) { 
            
        }
        transform.position = platformPos * Time.deltaTime; 
    }
}
