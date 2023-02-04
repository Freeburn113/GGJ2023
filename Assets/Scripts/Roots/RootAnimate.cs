using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAnimate : MonoBehaviour
{
    private SplineMesh splineMesh;
    private double _clip = 0.1;
    [SerializeField] private float animSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        splineMesh = GetComponent<SplineMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_clip < 1.0)
        {
            _clip += Time.deltaTime * animSpeed;
        }
        splineMesh.SetClipRange(0.0, _clip);
    }
}
