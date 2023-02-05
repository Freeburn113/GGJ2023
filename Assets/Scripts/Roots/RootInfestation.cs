using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootInfestation : MonoBehaviour
{
    public int startAtTime = 99999;
    private RootAnimate[] roots;

    // Start is called before the first frame update
    void Start()
    {
        startAtTime = Random.Range(30, 120);
        roots = GetComponentsInChildren<RootAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startAtTime) { Startinfestation(); startAtTime = (int)Time.time + Random.Range(30, 120); }
    }

    void Startinfestation()
    {
        foreach(RootAnimate root in roots)
        {
            root.targetGrowth = 1.0f;
        }
    }
}
