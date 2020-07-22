using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headRotator : MonoBehaviour
{
    public static headRotator hR;
    public float dataFromPowerMeter;
    public Animator anime;

    private void Start()
    {
        hR = this;
      
    }
    private void Update()
    {
        headRotation();
    }
    void headRotation()
    {
        if (GameManager.instence.shoot && Input.GetMouseButtonDown(0))
        {
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
            }*/
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
