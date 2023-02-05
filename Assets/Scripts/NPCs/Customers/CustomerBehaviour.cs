using System.Collections.Generic;
using Events.Events;
using Unity.VisualScripting;
using UnityEngine;


public class CustomerBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _id;
    
    public List<GameObject> Meshes;
    
    void Start()
    {
        CustomerEvent.Handlers += CustomerEventHandler;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void CustomerEventHandler(CustomerEvent e)
    {
        if(e.id != _id) return;
        ActivateMesh(e.meshId);
    }

    public void DeactiveMesh(int id)
    {
        if (id != _id) return;
        foreach (GameObject mesh in Meshes)
        {
            mesh.SetActive(false);
        }
    }
    
    
    public void ActivateMesh(int index)
    {
        foreach (GameObject mesh in Meshes)
        {
            mesh.SetActive(false);
        }
        Meshes[index].SetActive(true);
    }
}