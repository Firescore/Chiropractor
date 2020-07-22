using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager lManager;
    public GameManager gm;
    public GameObject EntryScene, MainScene,SwitchImage;
    public GameObject goToSeat, NextScene;
    public GameObject Chat;

    // Start is called before the first frame update
    void Start()
    {
        SwitchImage.SetActive(false);
        EntryScene.SetActive(true);
        MainScene.SetActive(false);
        goToSeat.SetActive(false);
        NextScene.SetActive(false);
        Chat.SetActive(false);
    }
    public void switchScene()
    {
        StartCoroutine(ss());
    }
    IEnumerator ss()
    {
        SwitchImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        EntryScene.SetActive(false);
        MainScene.SetActive(true);
        NextScene.SetActive(false);
        gm.setPos();
    }
}
