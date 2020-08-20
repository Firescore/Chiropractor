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


       transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, SceneMan.sceneMan.sliderVal * (-180));
        
        
    }
}
