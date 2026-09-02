using System;
using UnityEngine;
using UnityEngine.InputSystem;

interface Interactable
{
    public void Interact();
}



public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; //where the ray will come from(usually the camera)
    public float interactRange;//float to be modified for interact range of the raycast
    public InputActionReference interactKey;

    public void OnEnable()
    {
        interactKey.action.Enable();
    }
    public void OnDisable()
    {
        interactKey.action.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (interactKey.action.WasPressedThisFrame())//was E pressed?
        {
            Ray rayLine = new Ray(InteractorSource.position, InteractorSource.forward);//Make a new variable for ray that starts at the position of InteractorSource and then forward of it(ideal for camera)
            if(Physics.Raycast(rayLine,out RaycastHit hitInfo, interactRange))// if Raycast ray hits an object within interaction range, store that info inside RaycastHit variable called "hitInfo"
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out Interactable interactorObj))//if info comes back with gameobject that has a collider, has Interactable property called interactorObj(variable), then interact
                {
                    interactorObj.Interact();
                }
            }
        }  
    }
}
