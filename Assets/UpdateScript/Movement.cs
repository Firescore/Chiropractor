using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject bubbleText;
    public Animator anime;
    public Vector3[] walkPos;
    public float moveSpeed = 2;
    public float rotationSpeed = 2;

    void Start()
    {
        bubbleText.SetActive(false);
        transform.position = walkPos[0];
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
    }
    void moveForward()
    {
        float disFromP2 = 0;
        disFromP2 = Vector3.Distance(transform.position, walkPos[1]);

        if(transform.position == walkPos[1])
        {
            anime.SetBool("walk", false);
            bubbleText.SetActive(true);
            //anime.SetBool("talk", true);
        }
        if(transform.position != walkPos[1]&&disFromP2 <= 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkPos[1], moveSpeed * Time.deltaTime);
            anime.SetBool("walk", true);
        }
        if(transform.localRotation != Quaternion.Euler(0,90,0) && disFromP2<=0.58)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 90, 0), rotationSpeed*Time.deltaTime);
        }
    }
}
