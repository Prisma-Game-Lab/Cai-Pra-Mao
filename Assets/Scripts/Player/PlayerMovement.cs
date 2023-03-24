using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MaxplayerSpeed;
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 rawMovementVec;
    private Vector2 movementVec;

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        playerSpeed = movementVec.magnitude;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        // Limita a magnitude do vetor de movimento a 1, para evitar que movimentos na diagonal sejam mais rapidos
        movementVec = Vector2.ClampMagnitude(rawMovementVec, 1);

        // Escala o vetor de acordo com a velocidade do player e o tempo desde o ultimo frame
        movementVec *= MaxplayerSpeed * Time.fixedDeltaTime;

        // Aplica a movimentacao
        rb.MovePosition(rb.position + movementVec);
    }

    public void Jump()
    {
        return;
    }

    public void UpdateMovementVec(Vector2 rawMovementVec)
    {
        this.rawMovementVec = rawMovementVec;
    }
}
