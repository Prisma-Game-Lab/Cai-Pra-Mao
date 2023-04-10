using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombat playerCombat;

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
    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            StartCoroutine(playerMovement.Dash());
    }

    public void OnNormalAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            playerCombat.NormalAttack();
    }

    public void OnSpecialAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (playerCombat.character.name == "Toni")
            {
                playerCombat.ToniSpecialAttack();
            }
            else if (playerCombat.character.name == "Vector")
            {
                playerCombat.VectorSpecialAttack();
            }
        }
    }
}
