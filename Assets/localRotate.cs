using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localRotate : MonoBehaviour
{
    public Transform pos;
    public float speed;
    void Update()
    {
        StartCoroutine(transition(1.4f));
    }
    IEnumerator transition(float t)
    {
        yield return new WaitForSeconds(t);
        transform.position = Vector3.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pos.rotation, 0.8f * Time.deltaTime);
    }

}
