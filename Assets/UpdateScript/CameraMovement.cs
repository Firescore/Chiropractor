using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Animator anime;

    void Update()
    {
        StartCoroutine(transitionToBack());
        StartCoroutine(goUp());
        
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
        if (GameManager.gm.leftHPlaced && GameManager.gm.rightHPlaced)
            anime.SetBool("goUp", true);

        yield return new WaitForSeconds(0.5f);
        GameManager.gm.cameraPlacedUp = true;
    }
}
