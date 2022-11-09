using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraBehavior : MonoBehaviour
{
    public Transform following;
    float leftCon = -23f;
    float rightCon = 14f;
    float upCon = 3f;
    float downCon = 0f;
    public float ScreenX = 0f;
    public float ScreenY = 0f;

    void Start()
    {  
        Vector3 ObjPos = transform.position;
        ObjPos.x = 12f;
        transform.position = ObjPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ObjPos = transform.position;

        if ((following.position.x > leftCon) && (following.position.x < rightCon))
        {
            ObjPos.x = following.position.x + ScreenX;
        }
        if ((following.position.y > downCon) && (following.position.y < upCon))
        {
            ObjPos.y = following.position.y + ScreenY;
        }
        transform.position = ObjPos;

    }
    public void ChangeConstraints(float xMin, float xMax, float yMin, float yMax) {
        leftCon = xMin;
        rightCon = xMax;
        downCon = yMin;
        upCon = yMax;
        Vector3 ObjPos = transform.position;
        ObjPos.x = following.position.x + ScreenX;
        ObjPos.y = following.position.y + ScreenY;
        transform.position = ObjPos;
    }
    // x is offset -+ 7 and y is offset -+ 4
}
