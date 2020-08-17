using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    public static SceneMan sceneMan;
    public GameObject HandR, HandL, Head, indicator;
    public Slider headRotatorSlider;
    public GameObject bg1, bg2;
    public float sliderVal = 0f;

    bool a = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneMan = this;
        headRotatorSlider.value = 0.29f;
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
        if(GameManager.gm.leftH && GameManager.gm.rightH && !checkHead.checkH.a && !checkHead.checkH.b && !checkHead.checkH.c)
        {
            bg1.SetActive(true);
            bg2.SetActive(false);
            indicator.SetActive(true);
            headRotatorSlider.gameObject.SetActive(true);
        }
        if (checkHead.checkH.a && checkHead.checkH.b && checkHead.checkH.c)
            StartCoroutine(hideSlider());
    }
    public void enableScripts()
    {
        Head.GetComponent<Head>().enabled = true;
        HandL.GetComponent<HandL>().enabled = true;
        HandR.GetComponent<HandR>().enabled = true;
    }
    IEnumerator hideSlider()
    {
        if (!a)
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            indicator.SetActive(false);
            headRotatorSlider.gameObject.SetActive(false);
            a = true;
        }
    }
}
