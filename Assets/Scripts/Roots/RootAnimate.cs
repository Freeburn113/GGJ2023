using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAnimate : MonoBehaviour
{
    private SplineMesh _splineMesh;
    private float _growthProgress = 0.05f;
    public float targetGrowth = 0.05f;

    public bool doAnimate = false;

    // Start is called before the first frame update
    void Start()
    {
        _splineMesh = GetComponent<SplineMesh>();
        _splineMesh.SetClipRange(0.0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {

        if(targetGrowth > _growthProgress)
        {
            _growthProgress += 0.3f * Time.deltaTime;
        }
        else if(targetGrowth < _growthProgress)
        {
            _growthProgress -= 2.0f * Time.deltaTime;
        }

        if(_growthProgress < 0.05f)
        {
            _growthProgress = 0.05f;
        }
        _splineMesh.SetClipRange(0.0, _growthProgress);
    }
}
