using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject rHand,lHand,x_Ray;

    [Header("-------------------------------------------")]
    public Movement mv;
    public GameObject transitionImage;
    [Header("-------------------------------------------")]
    public bool handInIdlPos = false;

    void Start()
    {
        transitionImage.SetActive(false);
        gm = this;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        StartCoroutine(grab_X_Ray(1.5f));

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
            rHand.GetComponent<Animator>().SetBool("GrabEx",false);
            lHand.GetComponent<Animator>().SetBool("GrabEx", false);
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", false);
            yield return new WaitForSeconds(t);
            handInIdlPos = true;
        }

    }
    #endregion
}
