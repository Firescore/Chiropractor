using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rHand,lHand,x_Ray;

    [Header("-------------------------------------------")]
    public Movement mv;

    [Header("-------------------------------------------")]
    public bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(grab_X_Ray(1.5f));
        /*if (Movement.isRotationComplete && !isTrigger)
        {
            rHand.GetComponent<Animator>().SetTrigger("grab");
            lHand.GetComponent<Animator>().SetTrigger("grab");
            x_Ray.GetComponent<Animator>().SetTrigger("grab");
            isTrigger = true;
        }*/
    }
    IEnumerator grab_X_Ray(float t)
    {
        if (Movement.isRotationComplete && !isTrigger)
        {
            rHand.GetComponent<Animator>().SetBool("GrabEx", true);
            lHand.GetComponent<Animator>().SetBool("GrabEx", true);
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", true);
            yield return new WaitForSeconds(t);
            rHand.GetComponent<Animator>().SetBool("GrabEx",false);
            lHand.GetComponent<Animator>().SetBool("GrabEx", false);
            x_Ray.GetComponent<Animator>().SetBool("GrabEx", false);
            isTrigger = true;
        }

    }
}
