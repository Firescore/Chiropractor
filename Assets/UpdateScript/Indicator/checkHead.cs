using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHead : MonoBehaviour
{
    public static checkHead checkH;
    public bool a,b,c;
    float d;

    public Animator head1, lHand1, rHand1;
    private void Start()
    {
        checkH = this;
        head1.enabled = false;
        lHand1.enabled = false;
        rHand1.enabled = false;
        a = b = c = false;
    }
    void Update()
    {
        d = SceneMan.sceneMan.sliderVal;
        if(d >= 0.7 && d <= 0.79 && !a && !b && !c)
        {
            a = true;
        }

        if(a && !b && !c && d>= 0.21 && d <= 0.39)
        {
            b = true;
        }
        if(a && b && !c && d >= 0.7 && d <= 0.79)
        {
            c = true;
        }

        if (a && b && c)
        {
            UIManager.uIManager.AdjustNeck.GetComponent<Animator>().SetBool("out", true);
            UIManager.uIManager.FinalCrack.SetActive(true);
            SceneMan.sceneMan.Head.GetComponent<Head>().enabled = false;
            SceneMan.sceneMan.HandL.GetComponent<HandL>().enabled = false;
            SceneMan.sceneMan.HandR.GetComponent<HandR>().enabled = false;
            head1.enabled = true;
            lHand1.enabled = true;
            rHand1.enabled = true;
        }
    }
}
