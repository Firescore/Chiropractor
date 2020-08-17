using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public leftHandMovement lhm;
    public rightHandMovement rhm;
    public GameObject rHand,lHand,x_Ray,rootHand;

    [Header("-------------------------------------------")]
    public Movement mv;
    public GameObject transitionImage;
    public GameObject leftM, rightM;
    //public Slider slider;
    [Header("-------------------------------------------")]

    public float swipe = 0f;
    public float valueOfSlider = 0.5f;

    [Header("-------------------------------------------")]
    public bool cameraPlacedUp = false;

    public bool rightHPlaced = false;
    public bool leftHPlaced  = false; 
    public bool handInIdlPos = false;
    public bool handTeliport = false;
    public bool leftH = false;
    public bool rightH = false;

    void Start()
    {
        //slider.gameObject.SetActive(false);        
        transitionImage.SetActive(false);
        leftM.SetActive(false);
        rightM.SetActive(false);
        gm = this;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        leftHPlaced = lhm.handPlaced;
        rightHPlaced = rhm.handPlaced;
        StartCoroutine(grab_X_Ray(1.5f));
        StartCoroutine(desableAnime());
        StartCoroutine(enableAnime());
        handAnimation();
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region Scene 1
    IEnumerator grab_X_Ray(float t)
    {
        if (Movement.isRotationComplete && !handInIdlPos)
        {
            rHand.GetComponent<Animator>().SetBool("GrabEx", true);
/*          lHand.GetComponent<Animator>().SetBool("GrabEx", true);*/
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", true);
            yield return new WaitForSeconds(t);
            handInIdlPos = true;
            yield return new WaitForSeconds(1f);
            leftM.SetActive(true);
            rightM.SetActive(true);
            rHand.GetComponent<Animator>().SetBool("GrabEx", false);
/*          lHand.GetComponent<Animator>().SetBool("GrabEx", false);*/
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", false);
            
        }

    }
    #endregion

    #region Scene 2
    IEnumerator desableAnime()
    {
        if (handInIdlPos)
        {
            yield return new WaitForSeconds(1.5f);

            if (!handTeliport)
            {
                rootHand.transform.position = new Vector3(-35.32f, 1.05f, -7.72f);
                rootHand.transform.localRotation = Quaternion.Euler(0, 180, 0);
                yield return new WaitForSeconds(0.5f);
                rHand.GetComponent<Animator>().enabled = false;
                lHand.GetComponent<Animator>().enabled = false;
                handTeliport = true;
            }
            
        }
    }
    #endregion



    IEnumerator enableAnime()
    {
        if (leftHPlaced && rightHPlaced && !leftH && !rightH)
        {
            yield return new WaitForSeconds(0.1f);
            rightHandMovement.rhm.gameObject.transform.position = rightHandMovement.rhm.pos.position;
            rHand.GetComponent<Animator>().enabled = true;
            lHand.GetComponent<Animator>().enabled = true;
        }
    }
    
    void handAnimation()
    {
        if (cameraPlacedUp)
        {
            if(SwipeManager.swipeUp)
            {
                if(swipe <=6)
                    swipe += 1;

                if (swipe <= 6)
                {
                    rHand.GetComponent<Animator>().SetBool("grab", false);
                    lHand.GetComponent<Animator>().SetBool("grab", false);
                }
            }
            if(SwipeManager.swipeDown)
            {
                if (swipe <= 6)
                    swipe += 1;

                if (swipe <= 6)
                    {
                    rHand.GetComponent<Animator>().SetBool("grab", true);
                    lHand.GetComponent<Animator>().SetBool("grab", true);
                }
            }
        }
    }
}
