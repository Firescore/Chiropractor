using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static movement mv;
    public GameObject scanner;
    public Animator anime;
    public Transform[] pos;
    public float[] dist;
    public float speed = 2;
    public float stopTalkingT = 10;
    public bool FstReach = false;
    public bool isReach0 = false;
    public bool isReach1 = false;
    public bool isReach2 = false;
    public bool isReach3 = false;
    public bool isReach4 = false;

    bool stopWalking = false;
    bool stopTalking = false;
    public bool moveon = false;
    public bool isCharSit = false;
    void Start()
    {
        mv = this;
        Application.targetFrameRate = 60;
        scanner.SetActive(false);
    }

    void Update()
    {
        walkIn();
        walkToChair();
    }
    void walkIn()
    {
        dist[0] = Vector3.Distance(transform.position, pos[0].position);
        dist[1] = Vector3.Distance(transform.position, pos[1].position);
        dist[2] = Vector3.Distance(transform.position, pos[2].position);
        dist[3] = Vector3.Distance(transform.position, pos[3].position);
        dist[4] = Vector3.Distance(transform.position, pos[4].position);
        if (!FstReach)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[0].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[0].rotation, speed * Time.deltaTime);
        }
        if (isReach0)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[1].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[1].rotation, speed * Time.deltaTime);
        }
        if (isReach1)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[2].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[2].rotation, speed * Time.deltaTime);
        }
        if (isReach2)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[3].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[3].rotation, speed * Time.deltaTime);
        }
        if (isReach3)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[4].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[4].rotation, speed*5 * Time.deltaTime);
            anime.SetBool("walk", false);
            if(transform.rotation == pos[4].rotation)
            {
                anime.SetBool("sit", true);
                scanner.SetActive(true);
                isCharSit = true;
            }
        }

        

        if (dist[0] < 0.5f && !moveon)
        {
            stopWalking = true;
            anime.SetBool("walk", false);
        }

        if (stopWalking && !stopTalking &&!moveon)
        {

            StartCoroutine(startTalk(0.2f));
            StartCoroutine(stopTalk(stopTalkingT));
        }

    }
    void walkToChair()
    {

        if (moveon)
        {
            if (transform.position == pos[0].position)
            {
                FstReach = true;
                isReach0 = true;
            }
            if (transform.position == pos[1].position)
            {
                isReach0 = false;
                isReach1 = true;
            }
            if (transform.position == pos[2].position)
            {
                isReach1 = false;
                isReach2 = true;
            }
            if (transform.position == pos[3].position)
            {
                isReach2 = false;
                isReach3 = true;
            }
            if (transform.position == pos[4].position)
            {
                isReach4 = true;
            }
        }
    }
    public void moveOn()
    {
        moveon = true;

    }

    IEnumerator startTalk(float t)
    {
        yield return new WaitForSeconds(t);
        anime.SetBool("talk", true);
    }
    IEnumerator stopTalk(float t)
    {
        yield return new WaitForSeconds(t);
        anime.SetBool("talk", false);
        stopTalking = true;

    }
}
