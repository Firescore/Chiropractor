﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject bubbleText;
    public Animator anime;
    public Vector3[] walkPos;
    public float moveSpeed = 2;
    public float rotationSpeed = 2;

    private float _value = 1;
    private SpriteRenderer _chat;

    
    
    public static bool isRotationComplete = false;
    void Start()
    {
        bubbleText.SetActive(false);

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        _chat = bubbleText.GetComponent<SpriteRenderer>();
        Color c = _chat.material.color;
        c.a = _value;
        _chat.material.color = c;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        transform.position = walkPos[0];
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
        desableChatBubble();
        sit();
    }
    #region Scene 1
    void moveForward()
    {
        if (!GameManager.gm.handInIdlPos)
        {
            float disFromP2 = 0;
            disFromP2 = Vector3.Distance(transform.position, walkPos[1]);

            if (transform.position == walkPos[1])
            {
                anime.SetBool("walk", false);
                bubbleText.SetActive(true);
            }
            if (transform.position != walkPos[1] && disFromP2 <= 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, walkPos[1], moveSpeed * Time.deltaTime);
                anime.SetBool("walk", true);
            }
            if (transform.localRotation != Quaternion.Euler(0, 90, 0) && disFromP2 <= 0.58)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 90, 0), rotationSpeed * Time.deltaTime);
            }
            if (!isRotationComplete && transform.localRotation == Quaternion.Euler(0, 90, 0))
                isRotationComplete = true;
        }
        
    }
    #endregion
    #region Scene 2
    void sit()
    {
        if (GameManager.gm.handInIdlPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkPos[2], moveSpeed * Time.deltaTime);
            anime.SetBool("sit", true);
        }
    }

    void desableChatBubble()
    {
        if (GameManager.gm.handInIdlPos)
        {
            if (_value >= 0)
            {
                _value -= 0.1f;
            }
            if (bubbleText != null)
            {
                Color aC = _chat.material.color; ;
                aC.a = _value;
                _chat.material.color = aC;
            }
            if (_value <= 0)
            {
                Destroy(bubbleText.gameObject);
            }
        }
    }
    #endregion
}
