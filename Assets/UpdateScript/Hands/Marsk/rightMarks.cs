using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightMarks : MonoBehaviour
{
    public GameObject _hand;
    public Animator anime;
    public float speed = 5;

    private SpriteRenderer renderer;
    private float _Disance = 0f;
    private float _angle = 0f;
    //private Color c;

    void Start()
    {
        anime.enabled = false;
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
        if (_hand.GetComponent<rightHandMovement>().handPlaced)
        {
            renderer.material.color = Color.green;
            StartCoroutine(destroy());
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
    IEnumerator destroy()
    {
        anime.enabled = true;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);

    }
}
