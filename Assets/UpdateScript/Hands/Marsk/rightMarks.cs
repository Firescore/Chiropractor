using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightMarks : MonoBehaviour
{
    public GameObject _hand;
    public float speed = 5;

    private SpriteRenderer renderer;
    private float _Disance = 0f;
    private float _angle = 0f;
    //private Color c;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        colorChange();
        rotation();
        _Disance = Vector3.Distance(transform.position, _hand.transform.position);

    }

    void colorChange()
    {
        if (_hand.GetComponent<handMovement>().handPlaced)
        {
            renderer.material.color = Color.green;
        }
    }
    void rotation()
    {
        if (_angle <= 360)
        {
            _angle += speed * Time.deltaTime;
        }
        if (_angle >= 360)
        {
            _angle = 0;
        }
        transform.localRotation = Quaternion.Euler(0, 90, _angle);
    }
}
