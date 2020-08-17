using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandL : MonoBehaviour
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
        if (GameManager.gm.leftH)
        {
            slider();
        }
    }
    IEnumerator animationSart()
    {
        if(GameManager.gm.swipe >= 6 && !GameManager.gm.leftH)
        {
            yield return new WaitForSeconds(1f);
            _anime.SetBool("grabNeck", true);
            yield return new WaitForSeconds(1f);
            GameManager.gm.leftH = true;
            _anime.enabled = false;

        }
    }
    void slider()
    {
        a = SceneMan.sceneMan.sliderVal;
        if (a>=0.2 && a <= 0.8)
        {
            transform.localRotation = Quaternion.Euler(SceneMan.sceneMan.sliderVal * (-280), 180, -90);
        }
        //transform.localPosition = new Vector3(-0.5f, 0.3f, SceneMan.sceneMan.sliderVal * 0.5f);
        //animaion.transform.localRotation = Quaternion.Euler(animaion.transform.localRotation.x, SceneMan.sceneMan.sliderVal * (-130), animaion.transform.localRotation.z);
        //animaion.transform.localPosition = new Vector3(SceneMan.sceneMan.sliderVal/3f, animaion.transform.localPosition.y, animaion.transform.localPosition.z);
    }
}
