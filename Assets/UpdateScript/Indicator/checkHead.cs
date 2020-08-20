using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHead : MonoBehaviour
{
    public static checkHead checkH;
    public bool a, b, c, f, e, g;
    public bool faield = false, win = false;
    float d;

    public Animator head1, lHand1, rHand1;
    private void Start()
    {
        checkH = this;
        head1.enabled = false;
        lHand1.enabled = false;
        rHand1.enabled = false;
        a = b = c = f = e = g = false;
    }
    void Update()
    {
        d = SceneMan.sceneMan.sliderVal;

        if(d>=0.79 && d<=10 && !f && !e && a)
        {
            e = true;
        }

        if (a && b && !f && !c && d >= 0 && d <= 0.2)
        {
            f = true;
        }

        if (!g && a && b && c && d >= 0.8 && d <= 0.10)
        {
            g = true;
        }

        if (d >= 0.7 && d <= 0.79 && !a && !b && !c)
        {
            a = true;
        }

        if(a && !b && !c && d >= 0.21 && d <= 0.39)
        {
            b = true;
        }

        if(a && b && !c && d >= 0.7 && d <= 0.79)
        {
            c = true;
        }



        if (a && b && c)
        {
            if(!e && !f && !g)
            {
                UIManager.uIManager.AdjustNeck.GetComponent<Animator>().SetBool("out", true);
                UIManager.uIManager.FinalCrack.SetActive(true);
                SceneMan.sceneMan.Head.GetComponent<Head>().enabled = false;
                SceneMan.sceneMan.HandL.GetComponent<HandL>().enabled = false;
                SceneMan.sceneMan.HandR.GetComponent<HandR>().enabled = false;
                head1.enabled = true;
                lHand1.enabled = true;
                rHand1.enabled = true;
                if (!win)
                    win = true;
            }
            
        }
        if (a && b && c)
        {
            if (e || f || g)
            {
                UIManager.uIManager.AdjustNeck.GetComponent<Animator>().SetBool("out", true);
                UIManager.uIManager.FinalCrack.SetActive(true);
                SceneMan.sceneMan.Head.GetComponent<Head>().enabled = false;
                SceneMan.sceneMan.HandL.GetComponent<HandL>().enabled = false;
                SceneMan.sceneMan.HandR.GetComponent<HandR>().enabled = false;
                head1.enabled = true;
                lHand1.enabled = true;
                rHand1.enabled = true;

                if (!faield)
                    faield = true;
            }

        }
    }
}
