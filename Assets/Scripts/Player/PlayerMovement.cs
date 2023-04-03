using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private float MaxplayerSpeed;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float accel;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;
    private PlayerMovement opponent;
    private Rigidbody2D rb;
    private Vector2 rawMovementVec;
    private Vector2 movementVec;
    public float jumpAmount = 10;
    public float doubleJumpAmount = 10;
    private int normalizeHorizontalSpeed;
    private bool isGrounded;
    private bool doubleJumped;
    public bool isFacingRight = true;

    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    private bool isDashing;

    void Awake()
    {
        isGrounded = true;
        rb = GetComponentInParent<Rigidbody2D>();
        var playerMovements = FindObjectsOfType<PlayerMovement>();
        opponent = playerMovements.FirstOrDefault(m => m.GetPlayerIndex() != playerIndex);
        if (playerIndex == 0)
            isFacingRight = true;
        else
            isFacingRight = false;

    }

    private void FixedUpdate()
    {
        UpdateDirection();
        Move();
        CheckGrounded();
    }

    public void Move()
    {
        Vector2 targetVelocity;

        if (isDashing)
        {
            int direction = isFacingRight ? 1 : -1;
            rb.velocity = new Vector2(dashSpeed * direction, rb.velocity.y);
        }
        else
        {
            targetVelocity = new Vector2(playerSpeed * normalizeHorizontalSpeed, rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * accel);
        }

    }

    private void UpdateDirection()
    {
        if (rawMovementVec.x > 0)
        {
            normalizeHorizontalSpeed = 1;

            if (!isFacingRight)
                Flip();
        }
        else if (rawMovementVec.x < 0)
        {
            normalizeHorizontalSpeed = -1;

            if (isFacingRight)
                Flip();
        }
        else
            normalizeHorizontalSpeed = 0;

    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
        else if (!doubleJumped)
        {
            doubleJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpAmount);
        }
    }

    private void CheckGrounded()
    {
        var groundCol = Physics2D.OverlapArea(groundChecker.position, groundChecker.position + new Vector3(0.22f * (isFacingRight ? 1 : -1), -0.1f, 0), groundLayer);
        isGrounded = groundCol && rb.velocity.y < 1.0f ? true : false;

        if (isGrounded)
        {
            doubleJumped = false;
        }
    }


    public void UpdateMovementVec(Vector2 rawMovementVec)
    {
        this.rawMovementVec = rawMovementVec;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public IEnumerator Dash()
    {
        isDashing = true;

        yield return new WaitForSeconds(dashTime);

        isDashing = false;
    }
}
