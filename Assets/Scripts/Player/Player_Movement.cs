using UnityEngine;

public class Player_Movement : MonoBehaviour
{
   public enum AnimPlayerState
    {
        idle,
        walking,
        running
    }

    public AnimPlayerState currentPlayer;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float runningSpeed = 6f;
    [SerializeField] private float currentSpeed;

    private float horizontal;
    private float vertical;
     
    public CharacterController characterController;
    public Animator animator;
    
    private void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentSpeed = movementSpeed;
    }

    void Update()
    {
        Keyboard();
    }

    public void Keyboard()
    {
        CurrentStateMachine(AnimPlayerState.idle);
   
        horizontal = Input.GetAxis("Horizontal") * currentSpeed;
        vertical = Input.GetAxis("Vertical") * currentSpeed;

        if (horizontal != 0 || vertical != 0)
        {
            CurrentStateMachine(AnimPlayerState.walking);
        
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentStateMachine(AnimPlayerState.running);
        }
       

        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = transform.rotation * move;
        characterController.SimpleMove(move);
    }

    public void CurrentStateMachine(AnimPlayerState animPlayer)
    {
        currentPlayer = animPlayer;
        PlayerStateController(animPlayer);
    }
    public void PlayerStateController(AnimPlayerState currentState)
    {
        switch (currentState)
        {
            case AnimPlayerState.idle:
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
               
                break;
            case AnimPlayerState.walking:
                animator.SetBool("isWalking", true);
                currentSpeed = movementSpeed;
                
                break;
            case AnimPlayerState.running:
                animator.SetBool("isRunning", true);
                currentSpeed = runningSpeed;
                break;

        }
    }
}