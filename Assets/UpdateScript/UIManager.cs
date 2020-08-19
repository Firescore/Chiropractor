using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    public GameObject PlaceHandsInTheCircle;
    public GameObject SwipeDownToGrab;
    public GameObject AdjustNeck;
    public GameObject FinalCrack;
    void Start()
    {
        uIManager = this;
        PlaceHandsInTheCircle.SetActive(false);
        SwipeDownToGrab.SetActive(false);
        AdjustNeck.SetActive(false);
        FinalCrack.SetActive(false);
    }
}
