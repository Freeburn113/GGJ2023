using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootChopper : MonoBehaviour
{
    public List<SplineMesh> RootsChopped;
    [SerializeField] private GameObject _rootLoot;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SplineMesh>() != null)
        {
            if(!RootsChopped.Contains(other.GetComponent<SplineMesh>()))
            {
                RootAnimate rootAnimate = other.GetComponent<RootAnimate>();
                rootAnimate.targetGrowth = 0.05f;

                if (Random.Range(0.0f, 1.0f) > 0.8f)
                {
                    GameObject droppedRoot = Instantiate(_rootLoot, transform.position + transform.forward * 2.0f, transform.rotation);
                    droppedRoot.transform.position += new Vector3(0.0f, 2.0f, 0.0f);
                }
            }
        }
    }

    void StartChop()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    void StopChop()
    {
        GetComponent <BoxCollider>().enabled = false;
        RootsChopped.Clear();
    }
}