using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxSliderMassage : MonoBehaviour
{
    public static sfxSliderMassage sfx;
    public Image image;
    public GameObject[] stars, hideStar;
    public float time = 0.5f;
    private Slider _slider;
    private float _sliderValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }
    void Update()
    {
        sliderData();
    }
    void sliderData()
    {
        if (GameManager.gm.swipe == 1 && GameManager.gm.swipe < 2)
        {
            StartCoroutine(st1(time));
        }
        if (GameManager.gm.swipe > 2 && GameManager.gm.swipe == 3 && GameManager.gm.swipe < 4)
        {
            StartCoroutine(st2(time));
        }
        if (GameManager.gm.swipe >  4 && GameManager.gm.swipe == 5 && GameManager.gm.swipe < 6)
        {
            StartCoroutine(st3(time));
        }
    }
    IEnumerator st1(float t)
    {
        yield return new WaitForSeconds(t);
        if (_sliderValue <= 0.4f)
        {
            _sliderValue += 0.02f;
            _slider.value = _sliderValue;

        }
        if (_sliderValue >= 0.4f)
        {
            stars[0].SetActive(true);
            hideStar[0].SetActive(false);
        }
    }
    IEnumerator st2(float t)
    {
        yield return new WaitForSeconds(t);
        if (_sliderValue >= 0.4f && _sliderValue <= 0.8f)
        {
            _sliderValue += 0.02f;
            _slider.value = _sliderValue;

        }
        if (_sliderValue >= 0.8f)
        {
            stars[1].SetActive(true);
            hideStar[1].SetActive(false);
        }
    }
    IEnumerator st3(float t)
    {
        yield return new WaitForSeconds(t);
        if (_sliderValue >= 0.7f && _sliderValue <= 1f)
        {
            _sliderValue += 0.02f;
            _slider.value = _sliderValue;

        }
        if (_sliderValue >= 1f)
        {
            stars[2].SetActive(true);
            hideStar[2].SetActive(false);
        }
    }
}
