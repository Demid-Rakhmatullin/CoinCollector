using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float speed;


    void Update()
    {
        var input = playerInput.actions["Move"].ReadValue<Vector2>();
        var direction = new Vector3(input.x, 0f, input.y);
        characterController.SimpleMove(speed * Time.deltaTime * direction);
    }
}
