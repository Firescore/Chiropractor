using UnityEngine;
using System.Collections;
using TMPro;

public class ForcePower : MonoBehaviour
{
    public static ForcePower forcePower;
    public GameObject ball;
    public TextMeshPro powerValue;
    public Animator anime;
    public float amount = 0;
    public float maxValue = 0;
    public float minValue = 0;
    public float speed = 0;
    
    bool maxValueReached = false;
    bool minValueReached = false;

    public bool isMeterWorking = true;
    public bool startMeshing = false;
    private void Start()
    {
        anime.enabled = false;
        forcePower = this;
    }
    void Update()
    {
        if (!isMeterWorking)
        {
            
            if(amount >= 20 && amount <= 40)
            {
                powerValue.text = "89";
            }
            else
            {
                powerValue.text = amount.ToString();
            }
        }
        if (isMeterWorking)
        {
            AmountChnager(amount);
            PowerMeter();
        }

        if(GameManager.instence.shoot && Input.GetMouseButtonDown(0))
        {
            anime.enabled = true;            
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
