using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(transitionToBack());
    }
    IEnumerator transitionToBack()
    {
        if (GameManager.gm.handInIdlPos)
        {
            yield return new WaitForSeconds(1f);
            GameManager.gm.transitionImage.SetActive(true);
            GameManager.gm.x_Ray.SetActive(false);
            anime.SetBool("goBack", true);
        }
        
    }
}
