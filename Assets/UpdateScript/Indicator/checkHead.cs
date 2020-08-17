using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHead : MonoBehaviour
{
    public bool a,b,c;
    float d;
    public GameObject swipeLeft, swipeRight;
    private void Start()
    {
        swipeLeft.SetActive(false);
        swipeRight.SetActive(false);
        a = b = c = false;
    }
    void Update()
    {
        d = SceneMan.sceneMan.sliderVal;
        if(d >= 0.7 && d <= 0.79 && !a && !b && !c)
        {
            a = true;
            swipeLeft.SetActive(true);
        }

        if(a && !b && !c && d>= 0.21 && d <= 0.39)
        {
            b = true;
            swipeLeft.SetActive(false);
            swipeRight.SetActive(true);
        }
        if(a && b && !c && d >= 0.7 && d <= 0.79)
        {
            c = true;
        }
    }
}
