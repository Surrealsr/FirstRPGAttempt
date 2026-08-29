using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference movePlayer; // Player Move input
    public InputActionReference playerCamera;// Camera Look input
    public CharacterController playerControl; //Replacement for rigidbody on moving player
    public float playerSpeed = 5f;
    public Transform cameraTransform;

    private void OnEnable()
    {
        movePlayer.action.Enable();
        playerCamera.action.Enable();
    }
    private void OnDisable()
    {
        movePlayer.action.Disable();
        playerCamera.action.Disable();
    }

    public void Update()
    {   //saves the info of how the player is moving into moveInput
        Vector2 moveInput = movePlayer.action.ReadValue<Vector2>();
        float x = moveInput.x;
        float z = moveInput.y; //so that player doesnt go flying when you press W

        
        Vector3 cameraForward = cameraTransform.forward; //cameraForward now stores the coords for where the camera is facing
        Vector3 cameraRight = cameraTransform.right; //cameraRight now stores coords for what direction is to the right of the camera
        
        //Player flying because camera look up no good
        cameraForward.y = 0;
        cameraRight.y = 0;

        //Normalize will make them constant so the speed of player isn't irregular
        cameraForward.Normalize();
        cameraRight.Normalize();

        //playerDirection equals to the coords of where camera is facing and to the right of camera multiplied by x & z.
        Vector3 playerDirection = cameraForward * z + cameraRight * x;

        
        //The player controller for the player is the value of playerDirection multiplied by the float of playerSpeed multiplied by the realtime of the program so it moves at normal rate without being tied to FPS.
        playerControl.Move(playerDirection * playerSpeed * Time.deltaTime);

        rotatePlayer(cameraForward);//executes function

        void rotatePlayer(Vector3 cameraForward)// defines the function being executed
        {
            transform.rotation = Quaternion.LookRotation(cameraForward);//sets player rotation to rotation of cameraForward
        }

    }
    



















}
