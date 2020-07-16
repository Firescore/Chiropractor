using UnityEngine;

public class rightHand : MonoBehaviour
{

    public Animator anime;


    public float angle;
    public float angleToRotate;
    [Header("--------------------------------------------------------------")]
    public float anglX;
    public float angleToRotateX;
    [Header("--------------------------------------------------------------")]
    public float anglZ;
    public float angleToRotateZ;
    [Header("--------------------------------------------------------------")]
    public float dataFromPowerMeter;

    public float speed = 0;
    public static rightHand rH;
    bool run = false;
    private void Start()
    {
        rH = this;
        //transform.localEulerAngles = new Vector3(angle,transform.localEulerAngles.y, transform.localEulerAngles.z);
        //anglX = transform.localPosition.x;
        //anglZ = transform.localPosition.z;
    }
    private void Update()
    {
        
        animateArm();

    }
    void animateArm()
    {

        if (Input.GetMouseButtonDown(0) && GameManager.instence.shoot)
        {
            
            dataFromPowerMeter = ForcePower.forcePower.amount;

            if(dataFromPowerMeter>=6&& dataFromPowerMeter <= 19)
            {
                anime.SetBool("notwin", true);
            }
            if (dataFromPowerMeter >= 40 && dataFromPowerMeter <= 55)
            {
                anime.SetBool("notwin", true);
            }
            if (dataFromPowerMeter >= 20 && dataFromPowerMeter <= 39)
            {
                anime.SetBool("win", true);
            }
            if (dataFromPowerMeter >= 0 && dataFromPowerMeter <= 5)
            {
                anime.SetBool("lose", true);
            }
            if (dataFromPowerMeter >= 56 && dataFromPowerMeter <= 60)
            {
                anime.SetBool("lose", true);
            }
            run = true;
        }
        
    }
}
