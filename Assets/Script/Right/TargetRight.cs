using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRight : MonoBehaviour
{
    public static TargetRight TR;
    public ParticleSystem ps;

    private void Start()
    {
        TR = this;
    }
}
