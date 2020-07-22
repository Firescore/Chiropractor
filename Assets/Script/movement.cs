using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static movement mv;
    public levelManager lv;
    //public GameObject scanner;
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
        //scanner.SetActive(false);
    }

    void Update()
    {
        walkIn();
        if (stopTalking && !moveon)
        {
            lv.goToSeat.SetActive(true);
        }
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
        }
        if (isReach0)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[1].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[1].rotation, speed*3 * Time.deltaTime);
        }
        if (isReach1)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[2].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[2].rotation, speed*3 * Time.deltaTime);
        }
        if (isReach2)
        {
            anime.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, pos[3].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[3].rotation, speed*3 * Time.deltaTime);
        }
        if (isReach3)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[4].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos[4].rotation, speed*5 * Time.deltaTime);
            anime.SetBool("walk", false);
        }
        if (transform.rotation == pos[4].rotation)
        {
            anime.SetBool("sit", true);
            isCharSit = true;
            StartCoroutine(startTalk(1f));
            StartCoroutine(switchScreen(3f));
        }

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


    IEnumerator startTalk(float t)
    {
        yield return new WaitForSeconds(t);
        lv.Chat.SetActive(true);
    }
    IEnumerator switchScreen(float t)
    {
        yield return new WaitForSeconds(t);
        lv.switchScene();
    }
}
