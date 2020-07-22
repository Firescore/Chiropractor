using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instence;


    public GameObject powerMeter;
    public GameObject leftTar,rightTar;
    public GameObject leftHandAnime, rightHandAnime, headAnime;
    public GameObject cam, camTarget1, camTarget2;
    public GameObject handOnly,confetti,Text;
    public GameObject table;

    public Transform PlayerAnimatedData;
    public Transform PlayerAnimatedData_Pos;


    public Vector3 initialCamPs;
    public Vector3[] pos;

    public LayerMask withRigDol, withoutRigDol;

    public Animator Aanime;


    public float t;
    public float r = 0;
    public float speed = 0;
    public float camTransitionSpeed = 0;
    
    public bool isTargetPlacedLeft = false, isTargetPlacedRight = false;
    public bool shoot = false;
    public bool camWin = false,a=false,camLose = false,camNwin = false;
    public bool isSetUp = false;
    bool isTextShown = false;
    
    void Start()
    {
        table.SetActive(false);
        confetti.SetActive(false);
        Camera.main.cullingMask = withRigDol;
        initialCamPs = cam.transform.position;
        Application.targetFrameRate = 60;
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
            StartCoroutine(showPowerMeter(1.5f));
        }
        cameraMovement();
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        StartCoroutine(showTable(3.4f));
    }
    IEnumerator showPowerMeter(float time)
    {
        if (!a)
        {
            yield return new WaitForSeconds(time);
            powerMeter.SetActive(true);
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
        
        if (shoot && Input.GetMouseButtonDown(0))
        {
            
            if (ForcePower.forcePower.amount > 19 && ForcePower.forcePower.amount < 40)
            {
                camWin = true;
            }
            else if (ForcePower.forcePower.amount >= 6 && ForcePower.forcePower.amount <= 19)
            {
                camNwin = true;
            }
            else if (ForcePower.forcePower.amount >= 40 && ForcePower.forcePower.amount <= 55)
            {
                camNwin = true;
            }
            else if (headRotator.hR.dataFromPowerMeter >= 0 && headRotator.hR.dataFromPowerMeter <= 5)
            {
                camLose = true;
            }
            else if (headRotator.hR.dataFromPowerMeter >= 56 && headRotator.hR.dataFromPowerMeter <= 60)
            {
                camLose = true;
            }
        }

        if (camWin)
        {
            StartCoroutine(hidePowerMeter(2f));
            StartCoroutine(camWinlaunch(1f));
            StartCoroutine(win(9.3f));
        }
        if (camNwin)
        {
            
            StartCoroutine(Nwin(9.3f));
            if (!isTextShown)
            {
                StartCoroutine(tryAgainText());
                isTextShown = true;
            }
        }
        if (camLose)
        {
            PlayerAnimatedData.rotation = PlayerAnimatedData_Pos.rotation;
            StartCoroutine(hidePowerMeter(2f));
            StartCoroutine(camLoselaunch(1f));
            StartCoroutine(lose(9.3f));
        }
    }
    public void setPos()
    {
        leftHandAnime.transform.position = pos[0];
        rightHandAnime.transform.position = pos[1];
    }
    IEnumerator win(float t)
    {
        yield return new WaitForSeconds(t);
        handOnly.SetActive(false);
        Camera.main.cullingMask = withoutRigDol;
        Aanime.SetBool("happy", true);
        confetti.SetActive(true);

    }
    IEnumerator Nwin(float t)
    {
        if (!isSetUp)
        {
            camNwin = false;
            yield return new WaitForSeconds(t);
            ForcePower.forcePower.isMeterWorking = true;
            camWin = false;
            camLose = false;
            cam.transform.position = initialCamPs;
            rightHand.rH.anime.SetBool("notwin", false);
            leftHand.lH.anime.SetBool("notwin", false);
            headRotator.hR.anime.SetBool("notwin", false);
            ForcePower.forcePower.anime.enabled = false;
            isSetUp = true;
        }

    }
    IEnumerator tryAgainText()
    {
        yield return new WaitForSeconds(4f);
        Text.SetActive(true);
        yield return new WaitForSeconds(7f);
        Text.SetActive(false);
        isTextShown = true;

    }
    IEnumerator lose(float t)
    {
        yield return new WaitForSeconds(t);
        handOnly.SetActive(false);
        Camera.main.cullingMask = withoutRigDol;
        Aanime.SetBool("angry", true);
    }
    IEnumerator hidePowerMeter(float t)
    {
        yield return new WaitForSeconds(t);
        powerMeter.SetActive(false);
    }
    IEnumerator camWinlaunch(float t)
    {
        yield return new WaitForSeconds(t);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camTarget2.transform.position, 2.5f * Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(0, 180, 0), 4f * Time.deltaTime);
    }
    IEnumerator camLoselaunch(float t)
    {
        yield return new WaitForSeconds(t);
        
        cam.transform.position = Vector3.Lerp(cam.transform.position, camTarget2.transform.position, 2.5f * Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(0, 180, 0), 4f * Time.deltaTime);
    }
    IEnumerator showTable(float t)
    {
        yield return new WaitForSeconds(t);
        table.SetActive(true);
    }
}
