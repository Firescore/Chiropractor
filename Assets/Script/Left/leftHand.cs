using System.Collections;
using UnityEngine;

public class leftHand : MonoBehaviour
{
    public static leftHand lH;
    public Animator anime;
    [Header("--------------------------------------------------------------")]
    public float dataFromPowerMeter;

    private void Start()
    {
        lH = this;
        //transform.localEulerAngles = new Vector3(angleX, transform.localEulerAngles.y, transform.localEulerAngles.z);
        //posX = transform.localPosition.x;
        //posY = transform.localPosition.y;

    }
    private void Update()
    {

        animateArm();

    }
    void animateArm()
    {

        if (Input.GetMouseButtonDown(0) && GameManager.instence.shoot)
        {
            //anime.SetBool("notwin", true);
            dataFromPowerMeter = ForcePower.forcePower.amount;
            StartCoroutine(test(3f));
/*
            if (dataFromPowerMeter >= 6 && dataFromPowerMeter <= 19)
            {
                anime.SetBool("notwin", true);
            }
            if (dataFromPowerMeter >= 40 && dataFromPowerMeter <= 55)
            {
                anime.SetBool("notwin", true);
            }
            if (dataFromPowerMeter >= 20 && dataFromPowerMeter <= 39)
            {
                anime.SetBool("win", true);
            }
            if (dataFromPowerMeter >= 0 && dataFromPowerMeter <= 5)
            {
                anime.SetBool("lose", true);
            }
            if (dataFromPowerMeter >= 56 && dataFromPowerMeter <= 60)
            {
                anime.SetBool("lose", true);
            }
*/
        }
        
    }
    IEnumerator test(float t)
    {
        yield return new WaitForSeconds(t);
        if (dataFromPowerMeter >= 6 && dataFromPowerMeter <= 19)
        {
            //yield return new WaitForSeconds(t);
            anime.SetBool("notwin", true);
        }
        if (dataFromPowerMeter >= 40 && dataFromPowerMeter <= 55)
        {
            //yield return new WaitForSeconds(t);
            anime.SetBool("notwin", true);
        }
        if (dataFromPowerMeter >= 20 && dataFromPowerMeter <= 39)
        {
            //yield return new WaitForSeconds(t);
            anime.SetBool("win", true);
        }
        if (dataFromPowerMeter >= 0 && dataFromPowerMeter <= 5)
        {
            //yield return new WaitForSeconds(t);
            anime.SetBool("lose", true);
        }
        if (dataFromPowerMeter >= 56 && dataFromPowerMeter <= 60)
        {
            //yield return new WaitForSeconds(t);
            anime.SetBool("lose", true);
        }
    }
}
