using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLeft : MonoBehaviour
{
    public static TargetLeft TL;
    public ParticleSystem ps;

    private void Start()
    {
        TL = this;
    }

}
