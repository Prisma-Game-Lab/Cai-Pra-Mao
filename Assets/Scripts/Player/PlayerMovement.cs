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
    [SerializeField] private PlayerMovement opponent;
    private Rigidbody2D rb;
    private Vector2 rawMovementVec;
    private Vector2 movementVec;
    public float jumpAmount = 10;
    private int normalizeHorizontalSpeed;

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        var playerMovements = FindObjectsOfType<PlayerMovement>();
        opponent = playerMovements.FirstOrDefault(m => m.GetPlayerIndex() != playerIndex);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdateDirection();
        Move();
        LookAtOpponent();
    }

    public void Move()
    {
        Vector2 targetVelocity;

        if (normalizeHorizontalSpeed != 0)
        {
            targetVelocity = new Vector2(playerSpeed * normalizeHorizontalSpeed, rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * accel);
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
        }
        else if (rawMovementVec.x < 0)
        {
            normalizeHorizontalSpeed = -1;
        }
        else
            normalizeHorizontalSpeed = 0;

    }

    private void LookAtOpponent()
    {
        var relativePoint = transform.InverseTransformPoint(opponent.gameObject.transform.position);
        if (relativePoint.x < 0.0)
        {
            transform.localScale *= -1;
        }
    }

    public void Jump()
    {
        Debug.Log(Vector2.up * jumpAmount);
        rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        Debug.Log(rb.velocity);
    }

    public void UpdateMovementVec(Vector2 rawMovementVec)
    {
        this.rawMovementVec = rawMovementVec;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
}
