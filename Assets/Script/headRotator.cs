using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headRotator : MonoBehaviour
{
    public float angle;
    public float angleToRotate;
    public float dataFromPowerMeter;

    public Animator anime;
    public float speed = 0;
    bool rotate = false;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, angle, transform.localEulerAngles.z);
    }
    private void Update()
    {
        headRotation();
    }
    void headRotation()
    {
        if (GameManager.instence.shoot && Input.GetMouseButtonDown(0))
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

            rotate = true;
        }
    }
}
