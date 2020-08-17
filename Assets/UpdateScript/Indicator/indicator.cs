using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class indicator : MonoBehaviour
{

    private new SpriteRenderer renderer;
    public float a, r, g;
    private Color32 c;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        a = SceneMan.sceneMan.sliderVal;

        if (a <= 0.2)
        {
            r = 1;
            g = 0;
            c = new Color(r, g, 0, 1);
            renderer.material.color = c;
        }

        if(a >= 0.8)
        {
            r = 1;
            g = 0;
            c = new Color(r, g, 0, 1);
            renderer.material.color = c;
        }

        if(a>=0.21 && a <= 0.39)
        {
            g = 1;
            r = 0;
            c = new Color(r, g, 0, 1);
            renderer.material.color = c;
        }

        if(a>=0.7 && a <= 0.79)
        {
            g = 1;
            r = 0;
            c = new Color(r, g, 0, 1);
            renderer.material.color = c;
        }

        if(a>= 0.4 && a <= 0.69)
        {
            r = 1;
            g = 1;
            c = new Color(r, g, 1, 1);
            renderer.material.color = c;
        }


    }
}
