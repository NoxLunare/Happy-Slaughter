using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;

    private float horizontal;
    private float vertical;

    public CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
         horizontal = Input.GetAxis("Horizontal") * movementSpeed;
         vertical = Input.GetAxis("Vertical") * movementSpeed;
         
         Vector3 move = new Vector3 (horizontal, 0 , vertical);
         move = transform.rotation * move;
         characterController.Move(move * Time.deltaTime);
    
    }
}