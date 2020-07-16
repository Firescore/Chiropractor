using UnityEngine;
using TMPro;

public class ForcePower : MonoBehaviour
{
    public static ForcePower forcePower;
    public GameObject ball;
    public TextMeshPro powerValue;
    public float amount = 0;
    public float maxValue = 0;
    public float minValue = 0;
    public float speed = 0;

    bool maxValueReached = false;
    bool minValueReached = false;

    bool isMeterWorking = true;

    private void Start()
    {
        forcePower = this;
    }
    void Update()
    {
        if (!isMeterWorking)
        {
            powerValue.text = amount.ToString();
        }
        if (isMeterWorking)
        {
            AmountChnager(amount);
            PowerMeter();
        }

        if(GameManager.instence.shoot && Input.GetMouseButtonDown(0))
        {
            isMeterWorking = false;
        }

            
    }
    void AmountChnager(float amount)
    {
        float amount1 = (amount / maxValue) * 120.0f / 360;
        float buttonAngle = amount1 * 360;
        ball.transform.localEulerAngles = new Vector3(0, 0, buttonAngle);
    }
    void PowerMeter()
    {
        if(amount == maxValue)
        {
            maxValueReached = true;
            minValueReached = false;
        }
        if(amount == minValue)
        {
            maxValueReached = false;
            minValueReached = true;
        }
        if (maxValueReached)
            amount -= speed;
        if (minValueReached)
            amount += speed;
    }
}
