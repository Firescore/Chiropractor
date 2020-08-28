using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public leftHandMovement lhm;
    public rightHandMovement rhm;
    public GameObject rHand,lHand,x_Ray,rootHand;
    public Animator lC, rC;
    [Header("-------------------------------------------")]
    public Movement mv;
    public GameObject transitionImage;
    public GameObject leftM, rightM;
    public GameObject before;
    public GameObject HEmoji, AEmoji;
    public GameObject massageSlider, massageBarD, massageBarU;
    public GameObject[] HappyEmoji, AngryEmoji;
    public GameObject particleEffect, particleEffect2, particleEffect3, endLevelParticle;
    public Transform pos, EmotePos, splashParticle;

    public Transform LPT, RPT;
    //public Slider slider;
    [Header("-------------------------------------------")]

    public float swipe = 0f;
    public float valueOfSlider = 0.5f;
    public float coolDown = 1;
    public float swipeRate = 1;

    [Header("-------------------------------------------")]
    public bool cameraPlacedUp = false;

    public bool rightHPlaced = false;
    public bool leftHPlaced  = false; 
    public bool handInIdlPos = false;
    public bool handTeliport = false;
    public bool leftH = false;
    public bool rightH = false;
    public bool chiropracterStarted = false;

    bool win = false, fail = false, win2 = false;
    void Start()
    {
        //slider.gameObject.SetActive(false);    
        massageSlider.SetActive(false);
        massageBarD.SetActive(false);
        massageBarU.SetActive(false);
        transitionImage.SetActive(false);
        endLevelParticle.SetActive(false);
        before.SetActive(false);
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
        finalCrack();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (levelManager.levelMan.gameOver)
        {
            rootHand.SetActive(false);
        }
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
            yield return new WaitForSeconds(1.2f);
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
            massageSlider.SetActive(true);
            massageBarD.SetActive(true);
            coolDown -= Time.deltaTime;
            if (SwipeManager.swipeUp && coolDown <=0)
            {
                if(swipe <=6)
                    swipe += 1;

                if (swipe <= 6)
                {
                    coolDown = 1 / swipeRate;
                   
                    UIManager.uIManager.SwipeUpToRelese.GetComponent<Animator>().SetBool("out", true);

                    UIManager.uIManager.SwipeDownToGrab.GetComponent<Animator>().SetBool("out", false);
                    lC.SetBool("up", false);
                    rC.SetBool("up", false);
                    rHand.GetComponent<Animator>().SetBool("grab", false);
                    lHand.GetComponent<Animator>().SetBool("grab", false);
                }
            }
            if(SwipeManager.swipeDown && coolDown <=0)
            {
                if (swipe <= 6)
                    swipe += 1;

                if (swipe <= 5)
                {
                    coolDown = 1 / swipeRate;
                    StartCoroutine(grab(0.5f));
                }
            }
        }
        if (swipe >= 6)
        {
            massageSlider.SetActive(false);
        }
        if (swipe >= 1)
        {
            massageBarD.SetActive(false);
        }
    }
    IEnumerator grab(float t)
    {
        UIManager.uIManager.SwipeDownToGrab.GetComponent<Animator>().SetBool("out", true);
        UIManager.uIManager.SwipeUpToRelese.SetActive(true);
        UIManager.uIManager.SwipeUpToRelese.GetComponent<Animator>().SetBool("out", false);
        rHand.GetComponent<Animator>().SetBool("grab", true);
        lHand.GetComponent<Animator>().SetBool("grab", true);
        yield return new WaitForSeconds(0.17f);
        lC.SetBool("up", true);
        rC.SetBool("up", true);
        yield return new WaitForSeconds(0.23f);
        int rand = Random.Range(0, 3);
        GameObject hE1 = Instantiate(HappyEmoji[rand], pos.position, Quaternion.Euler(35, 90, 0));
        GameObject hE = Instantiate(particleEffect, LPT.position, Quaternion.identity);
        GameObject hE2 = Instantiate(particleEffect, RPT.position, Quaternion.identity);
        hE.transform.parent = LPT;
        hE2.transform.parent = RPT;
        Destroy(hE, 4f);
    }
    void finalCrack()
    {
        if(checkHead.checkH.win && SwipeManager.swipeLeft && !chiropracterStarted)
        {
            happyEmoji();
            SceneMan.sceneMan.progressBar.gameObject.SetActive(false);
            checkHead.checkH.head1.SetBool("win", true);
            checkHead.checkH.lHand1.SetBool("win", true);
            checkHead.checkH.rHand1.SetBool("win", true);
            chiropracterStarted = true;
        }
        if (checkHead.checkH.faield && SwipeManager.swipeLeft && !chiropracterStarted)
        {
            
            SceneMan.sceneMan.progressBar.gameObject.SetActive(false);
            checkHead.checkH.head1.SetBool("lose", true);
            checkHead.checkH.lHand1.SetBool("lose", true);
            checkHead.checkH.rHand1.SetBool("lose", true);
            chiropracterStarted = true;
        }
        happyEmoji();
        angryEmoji();
    }
    void happyEmoji()
    {
        if (levelManager.levelMan.gameOver && !win && checkHead.checkH.win)
        {
            StartCoroutine(WinEmot());
            StartCoroutine(Win());
        }
        if (levelManager.levelMan.gameOver && !win2 && checkHead.checkH.win)
        {
            GameObject pE = Instantiate(particleEffect2, splashParticle.position, Quaternion.Euler(0, 90, 0));
            GameObject pE2 = Instantiate(particleEffect3, splashParticle.position, Quaternion.Euler(0, 90, 0));
            pE.transform.parent = splashParticle;
            pE2.transform.parent = splashParticle;
            Destroy(pE, 2f);
            Destroy(pE2, 2f);
            win2 = true;
        }
    }
    void angryEmoji()
    {
        if (levelManager.levelMan.gameOver && !fail && checkHead.checkH.faield)
        {
            Destroy(Instantiate(AEmoji, EmotePos.position, Quaternion.Euler(0, 180, 0)), 2);
            Destroy(Instantiate(particleEffect3, splashParticle.position, Quaternion.identity), 2);
            fail = true;
        }

    }

    IEnumerator WinEmot()
    {
        while (!win)
        {
            float rand = Random.Range(-6f, -9f);
            Destroy(Instantiate(HEmoji, new Vector3(-33.9f, 1f, rand), Quaternion.Euler(0, 180, 0)), 2);
            yield return new WaitForSeconds(3.5f);
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(1);
        win = true;
    }
}
