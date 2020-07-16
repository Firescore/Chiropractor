using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHand : MonoBehaviour
{
    public Animator anime;



    public float angleX;
    public float angleToRotateX;
    [Header("--------------------------------------------------------------")]
    public float posX;
    public float posToRotateX;
    [Header("--------------------------------------------------------------")]
    public float posY;
    public float posToRotateY;
    [Header("--------------------------------------------------------------")]
    public float dataFromPowerMeter;

    public float speed = 0;
    public static leftHand lH;
    bool run = false;
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
            run = true;
        }
        
    }
}
