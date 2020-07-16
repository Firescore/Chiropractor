using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform[] pos;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotator();
    }
    void rotator()
    {
        if (movement.mv.moveon)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            
        }
        if (movement.mv.isCharSit)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            transform.position = Vector3.Lerp(transform.position, pos[1].position, (speed * 5) * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[1].rotation, speed * Time.deltaTime);
        }
    }
}
