using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float a;
    void Start()
    {
       
    }
    void Update()
    {
        a = SceneMan.sceneMan.sliderVal;

        if (a >= 0.2 && a <= 0.8)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, SceneMan.sceneMan.sliderVal * (-180));
        }
        
    }
}
