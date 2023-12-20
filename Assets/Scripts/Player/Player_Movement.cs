using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;

    private float horizontal;
    private float vertical;

    public CharacterController characterController;
    public Animator animator;
    
    private void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        Keyboard();
    }

    public void Keyboard()
    {
        animator.SetBool("isWalking", false);
     
        horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        vertical = Input.GetAxis("Vertical") * movementSpeed;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isWalking",true);
      
            
        }

        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = transform.rotation * move;
        characterController.SimpleMove(move);
    }
}