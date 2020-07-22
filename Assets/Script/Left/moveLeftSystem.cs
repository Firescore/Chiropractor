using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftSystem : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    
    public Camera cam;
    public GameObject target;

    bool mouseMoving = false;
    float targetX;
    float targetY;
    private void Start()
    {
    }
    public void Update()
    {
        if (mouseMoving)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
    void OnMouseDown()
    {

        mZCoord = cam.WorldToScreenPoint(
            gameObject.transform.position).z;

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
        targetX = Mathf.Abs(transform.position.x - target.transform.position.x);
        targetY = Mathf.Abs(transform.position.y - target.transform.position.y);

        if(targetX<=0.7f && targetY <= 0.7f)
        {
            GameManager.instence.isTargetPlacedLeft = true;
            gameObject.GetComponent<leftHand>().enabled = true;
            
            if (gameObject.GetComponent<moveLeftSystem>().enabled != false)
            {
                gameObject.GetComponent<moveLeftSystem>().enabled = false;
            }
        }
    }

}
