using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference movePlayer; // Player Move input
    public InputActionReference playerJump; // Player Jump input
    public InputActionReference playerCamera;// Camera Look input
    public CharacterController playerControl; //Replacement for rigidbody on moving player, solves problem of movement issues with objects
        
    public float playerSpeed = 5f;
    public float playerGravity = -9f;
    float fallSpeed;
    Transform cameraTransform;
   

    private void OnEnable()
    {
        movePlayer.action.Enable();
        playerCamera.action.Enable();
        playerJump.action.Enable();
    }
    private void OnDisable()
    {
        movePlayer.action.Disable();
        playerCamera.action.Disable();
        playerJump.action.Disable();
    }
    void Start()
    {
      cameraTransform = Camera.main.transform;//solves problem of cameratransform dissapearing when you delete the object and replace with prefab
                                                      //Basically makes cameraTransform equal to the tranform of the object with "MainCamera" Tag
    }

    public void Update()
    {   
        Vector2 moveInput = movePlayer.action.ReadValue<Vector2>();//saves the info of how the player is moving into moveInput
        float x = moveInput.x;
        float z = moveInput.y; //so that player doesnt go flying when you press W

        
        Vector3 cameraForward = cameraTransform.forward; //cameraForward now stores the coords for where the camera is facing
        Vector3 cameraRight = cameraTransform.right; //cameraRight now stores coords for what direction is to the right of the camera
        
        cameraForward.y = 0;//Player flying because camera look up no good
        cameraRight.y = 0;

        cameraForward.Normalize();//Normalize will make them constant so the speed of player isn't irregular
        cameraRight.Normalize();

        Vector3 playerDirection = cameraForward * z + cameraRight * x;//playerDirection equals to the coords of where camera is facing and to the right of camera multiplied by x & z.


        playerControl.Move(playerDirection * playerSpeed * Time.deltaTime);//The player controller for the player is the value of playerDirection multiplied by the float of playerSpeed multiplied by the realtime of the program so it moves at normal rate without being tied to FPS.

        rotatePlayer(cameraForward);

        void rotatePlayer(Vector3 cameraForward)
        {
            transform.rotation = Quaternion.LookRotation(cameraForward);//sets player rotation to rotation of cameraForward using Quaternion function
        }

        fallSpeed += playerGravity * Time.deltaTime;
        playerControl.Move(Vector3.up * fallSpeed * Time.deltaTime); //calculates the way the player falls(gravity)



    }
    

}
