using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject rHand,lHand,x_Ray,rootHand;

    [Header("-------------------------------------------")]
    public Movement mv;
    public GameObject transitionImage;
    public GameObject leftM, rightM;
    [Header("-------------------------------------------")]

    public bool leftHPlaced = false; 
    public bool rightHPlaced = false;
    public bool cameraPlacedUp = false;

    public bool handInIdlPos = false;
    public bool handTeliport = false;

    void Start()
    {
        transitionImage.SetActive(false);
        leftM.SetActive(false);
        rightM.SetActive(false);
        gm = this;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        leftHPlaced = lHand.GetComponent<leftHandMovement>().handPlaced;
        rightHPlaced = rHand.GetComponent<rightHandMovement>().handPlaced;
        StartCoroutine(grab_X_Ray(1.5f));
        StartCoroutine(desableAnime());
        StartCoroutine(enableAnime());

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region Scene 1
    IEnumerator grab_X_Ray(float t)
    {
        if (Movement.isRotationComplete && !handInIdlPos)
        {
            rHand.GetComponent<Animator>().SetBool("GrabEx", true);
            lHand.GetComponent<Animator>().SetBool("GrabEx", true);
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", true);
            yield return new WaitForSeconds(t);
            handInIdlPos = true;
            yield return new WaitForSeconds(1f);
            leftM.SetActive(true);
            rightM.SetActive(true);
            rHand.GetComponent<Animator>().SetBool("GrabEx", false);
            lHand.GetComponent<Animator>().SetBool("GrabEx", false);
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
                rootHand.transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 180, 0),50*Time.deltaTime);
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
        if (leftHPlaced && rightHPlaced)
        {
            yield return new WaitForSeconds(0.1f);
            rHand.GetComponent<Animator>().enabled = true;
            rHand.GetComponent<Animator>().SetBool("Solder", true);
            lHand.GetComponent<Animator>().enabled = true;
        }
    }
}
