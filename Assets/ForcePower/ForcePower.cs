using UnityEngine;
using System.Collections;
using TMPro;

public class ForcePower : MonoBehaviour
{
    public GameObject ball;
    public float amount = 0;
    public float maxValue = 0;
    //public float minValue = 0;
    public float a = 0;

    void Update()
    {
        a = SceneMan.sceneMan.sliderVal;
        if (a <= 0.5f)
        {
            amount = (2 * a) - 1;
        }
        if (a >= 0.5f)
        {
            amount = Mathf.Abs(1 - (2 * a));
        }
        AmountChnager(amount);

       
    }
    void AmountChnager(float amount)
    {
        float amount1 = (amount / maxValue) * 13.0f / 30;
        float buttonAngle = amount1 * 360;
        ball.transform.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    }
}
