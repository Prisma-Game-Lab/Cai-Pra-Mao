using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {

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

        playerMovement.UpdateMovementVec(moveVec);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        playerMovement.Jump();
    }
}
