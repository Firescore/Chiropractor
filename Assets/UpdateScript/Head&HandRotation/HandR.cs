using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandR : MonoBehaviour
{
    public GameObject animaion;
    private Animator _anime;
    public float a;
    void Start()
    {
        _anime = animaion.GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(animationSart());
        if (GameManager.gm.rightH)
        {
            slider();
        }

    }
    IEnumerator animationSart()
    {
        if (GameManager.gm.swipe >= 6 && !GameManager.gm.rightH)
        {
            yield return new WaitForSeconds(1f);
            _anime.SetBool("grabNeck", true);
            yield return new WaitForSeconds(1f);
            GameManager.gm.rightH = true;
            _anime.enabled = false;
        }
    }
    void slider()
    {
        a = SceneMan.sceneMan.sliderVal;

            transform.localRotation =  Quaternion.Euler(SceneMan.sceneMan.sliderVal * 220,0,90);
            transform.localPosition = new Vector3(-0.5f, 0.5f - SceneMan.sceneMan.sliderVal/4, SceneMan.sceneMan.sliderVal * 0.5f);
        
    }
}
