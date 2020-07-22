using UnityEngine;

public class TargetLeft : MonoBehaviour
{
    public static TargetLeft TL;
    public Material sp;
    public float speed=5;
    Color32 color;
    float angle;
    public Animator anime;

    private void Start()
    {
        anime.enabled = false;
        color = Color.red;
        color.a = 170;
        sp.color = color;
        sp.SetColor("_EmissionColor", color);
        TL = this;
    }

    [System.Obsolete]
    private void Update()
    {
        angle += Time.deltaTime * speed;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y,angle);
        if (GameManager.instence.isTargetPlacedLeft)
        {
            color = Color.green;
            sp.color = color;
            sp.SetColor("_EmissionColor", color);
            anime.enabled = true ;

        }
    }

}
