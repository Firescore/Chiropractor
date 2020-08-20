using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement camMove;
    public Animator anime;

    private void Start()
    {
        camMove = this;
    }
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
            yield return new WaitForSeconds(1);
            UIManager.uIManager.PlaceHandsInTheCircle.SetActive(true);
        } 
    }
    IEnumerator goUp()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.gm.leftHPlaced && GameManager.gm.rightHPlaced && GameManager.gm.swipe <= 5)
        {
            UIManager.uIManager.PlaceHandsInTheCircle.GetComponent<Animator>().SetBool("out", true);
            yield return new WaitForSeconds(0.5f);
            UIManager.uIManager.SwipeDownToGrab.SetActive(true);  
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
