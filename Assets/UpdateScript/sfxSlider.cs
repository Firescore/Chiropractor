using UnityEngine;
using UnityEngine.UI;

public class sfxSlider : MonoBehaviour
{
    public Image image;
    public GameObject[] stars, hideStars;
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
        if (checkHead.checkH.a && !checkHead.checkH.b && !checkHead.checkH.c && !checkHead.checkH.e && !checkHead.checkH.f && !checkHead.checkH.g)
        {
            if (_sliderValue <= 0.4f)
            {
                _sliderValue += 0.02f;                
                _slider.value = _sliderValue;
                
            }
            if(_sliderValue >= 0.4f)
            {
                stars[0].SetActive(true);
                hideStars[0].SetActive(false);
            }
        }
        if (checkHead.checkH.a && checkHead.checkH.b && !checkHead.checkH.c && !checkHead.checkH.e && !checkHead.checkH.f && !checkHead.checkH.g)
        {
            if (_sliderValue >= 0.4f && _sliderValue <= 0.8f)
            {
                _sliderValue += 0.02f;
                _slider.value = _sliderValue;
                
            }
            if (_sliderValue >= 0.8f)
            {
                stars[1].SetActive(true);
                hideStars[1].SetActive(false);
            }
        }
        if (checkHead.checkH.a && checkHead.checkH.b && checkHead.checkH.c && !checkHead.checkH.e && !checkHead.checkH.f && !checkHead.checkH.g)
        {
            if (_sliderValue >= 0.8f && _sliderValue <= 1f)
            {
                _sliderValue += 0.02f;
                _slider.value = _sliderValue;
               
            }
            if (_sliderValue >= 1f)
            {
                stars[2].SetActive(true);
                hideStars[2].SetActive(false);
            }
        }
    }
}
