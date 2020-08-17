using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    public static SceneMan sceneMan;
    public GameObject HandR, HandL, Head, indicator;
    public Slider headRotatorSlider;
    public float sliderVal = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sceneMan = this;
        headRotatorSlider.value = 0.2f;
        indicator.SetActive(false);
        headRotatorSlider.gameObject.SetActive(false);
        //Head.GetComponent<Head>().enabled = false;
        HandL.GetComponent<HandL>().enabled = false;
        HandR.GetComponent<HandR>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        sliderVal = headRotatorSlider.value;
        if(GameManager.gm.leftH && GameManager.gm.rightH)
        {
            indicator.SetActive(true);
            headRotatorSlider.gameObject.SetActive(true);
        }
    }
    public void enableScripts()
    {
        Head.GetComponent<Head>().enabled = true;
        HandL.GetComponent<HandL>().enabled = true;
        HandR.GetComponent<HandR>().enabled = true;
    }
}
