using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

interface Interactable
{
    public void Interact();
}



public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; //where the ray will come from(usually the camera)
    public float interactRange;//float to be modified for interact range of the raycast
    public InputActionReference interactKey;
    public TMP_Text interactText;
    public float sphereRadius = 0.3f;

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
        if (interactKey.action.WasPressedThisFrame())
        {
            Ray rayLine = new Ray(InteractorSource.position, InteractorSource.forward);//Make a new variable for ray that starts at the position of InteractorSource and then forward of it(ideal for camera)
            if (Physics.SphereCast(rayLine, sphereRadius, out RaycastHit hitInfo, interactRange))// if Raycast ray hits an object within interaction range, store that info inside RaycastHit variable called "hitInfo"
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactableObj))//if info comes back with gameobject that has a collider, has Interactable property called interactorObj(variable), then interact
                {
                    interactableObj.Interact();
                }
            }
        }
    }
    private void OnDrawGizmos()//Something I learned to make visual lines for invisible hitboxes, such as Raycasts. Now you can adjust the floats and actually see the adjustments.
    {
        if (InteractorSource == null)
            return;
        Gizmos.DrawWireSphere(InteractorSource.position + InteractorSource.forward * interactRange, sphereRadius);

        Gizmos.DrawLine(InteractorSource.position, InteractorSource.position + InteractorSource.forward * interactRange);



        

        
    }
}
