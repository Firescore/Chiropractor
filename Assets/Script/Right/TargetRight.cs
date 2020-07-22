using UnityEngine;

public class TargetRight : MonoBehaviour
{
    public static TargetRight TR;
    public Material sp;
    public float speed = 5;
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
        TR = this;
    }
    private void Update()
    {
        angle -= Time.deltaTime * speed;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
        if (GameManager.instence.isTargetPlacedRight)
        {
            color = Color.green;
            sp.color = color;
            sp.SetColor("_EmissionColor", color);
            anime.enabled = true;

        }
    }
}
