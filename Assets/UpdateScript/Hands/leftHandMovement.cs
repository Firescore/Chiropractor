using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandMovement : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public Transform pos;
    public float angleRotate;
    public bool handPlaced = false;

    private Vector3 mOffset;
    private float mZCoord;

    bool mouseMoving = false;
    float targetX;
    float targetY;
    public void Update()
    {
        if (mouseMoving && !GameManager.gm.leftHPlaced)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
        targetX = Mathf.Abs(transform.position.x - target.transform.position.x);
        targetY = Mathf.Abs(transform.position.y - target.transform.position.y);
    }
    void OnMouseDown()
    {

        mZCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        mouseMoving = true;


    }


    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;


        // z coordinate of game object on screen

        mousePoint.z = mZCoord;


        // Convert it to world points

        return cam.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseUp()
    {
        mouseMoving = false;
        if (targetX <= 0.07f && targetY <= 0.03f)
        {
            transform.position = pos.position;
            transform.localRotation = Quaternion.Euler(0, angleRotate, 0);
            handPlaced = true;
        }
    }
}
