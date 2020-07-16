using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instence;
    public GameObject powerMeter;
    public GameObject leftTar,rightTar;
    public GameObject leftHandAnime, rightHandAnime, headAnime;
    public GameObject cam, camTarget;

    public bool isTargetPlacedLeft = false, isTargetPlacedRight = false;
    public float r = 0;
    public float speed = 0;
    public float camTransitionSpeed = 0;
    public bool shoot = false;
    bool isCamLerp = false,a=false;
    
    
    void Start()
    {
        instence = this;
        powerMeter.SetActive(false);
        leftHandAnime.GetComponent<Animator>().enabled = false;
        rightHandAnime.GetComponent<Animator>().enabled = false;
        headAnime.GetComponent<Animator>().enabled = false;
    }

    
    void Update()
    {
        if(isTargetPlacedLeft && isTargetPlacedRight)
        {
            StartCoroutine(showPowerMeter(0.5f));
        }
        cameraMovement();
    }
    IEnumerator showPowerMeter(float time)
    {
        if (!a)
        {
            yield return new WaitForSeconds(time);
            powerMeter.SetActive(true);
            //targetHead.SetActive(true);
            shoot = true;
            leftTar.SetActive(false);
            rightTar.SetActive(false);
            leftHandAnime.GetComponent<Animator>().enabled = true;
            rightHandAnime.GetComponent<Animator>().enabled = true;
            headAnime.GetComponent<Animator>().enabled = true;
            a = true;
        }
        
    }
    void cameraMovement()
    {
        if (!isCamLerp && shoot && Input.GetMouseButtonDown(0))
        {
            isCamLerp = true;
        }
        if (isCamLerp)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, camTarget.transform.position, camTransitionSpeed * Time.deltaTime);
            cam.transform.localEulerAngles = camTarget.transform.localEulerAngles;
        }
    }
}
