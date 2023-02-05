using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCauldronContents : MonoBehaviour
{
    private ParticleSystem _particles;
    public Mesh[] testMeshArray;

    // Start is called before the first frame update
    void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        setContentMesh(testMeshArray);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setContentMesh(Mesh[] contents)
    {
        _particles.GetComponent<ParticleSystemRenderer>().SetMeshes(contents);
    }
}
