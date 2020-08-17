﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Animator anime;

    void Update()
    {
        StartCoroutine(transitionToBack());
        StartCoroutine(goUp());
        cameraGoBack();


    }
    IEnumerator transitionToBack()
    {
        if (GameManager.gm.handInIdlPos)
        {
            yield return new WaitForSeconds(1f);
            GameManager.gm.transitionImage.SetActive(true);
            GameManager.gm.x_Ray.SetActive(false);
            anime.SetBool("goBack", true);
        } 
    }
    IEnumerator goUp()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.gm.leftHPlaced && GameManager.gm.rightHPlaced && GameManager.gm.swipe <= 5)
        {
            anime.SetBool("goUp", true);
            yield return new WaitForSeconds(0.65f);
            GameManager.gm.cameraPlacedUp = true;
        }

    }
    void cameraGoBack()
    {
        if (GameManager.gm.swipe >=5)
        {
            anime.SetBool("goUp", false);
            SceneMan.sceneMan.enableScripts();
        }
    }
}
