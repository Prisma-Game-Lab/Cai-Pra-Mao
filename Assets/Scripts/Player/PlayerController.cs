using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var playerMovements = FindObjectsOfType<PlayerMovement>();
        var index = playerInput.playerIndex;
        playerMovement = playerMovements.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 moveVec = ctx.ReadValue<Vector2>();

        if (moveVec.y > 0)
            moveVec.y = 0;

        if (playerMovement)
            playerMovement.UpdateMovementVec(moveVec);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            playerMovement.Jump();
    }
}
