using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private float MaxplayerSpeed;
    [SerializeField] private float playerSpeed;
    [SerializeField] private PlayerMovement opponent;
    private Rigidbody2D rb;
    private Vector2 rawMovementVec;
    private Vector2 movementVec;
    public float jumpAmount = 10;

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        var playerMovements = FindObjectsOfType<PlayerMovement>();
        opponent = playerMovements.FirstOrDefault(m => m.GetPlayerIndex() != playerIndex);
    }

    void Update()
    {
        playerSpeed = movementVec.magnitude;
    }

    private void FixedUpdate()
    {
        Move();
        LookAtOpponent();
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
        rb.AddForce(Vector2.up*jumpAmount, ForceMode2D.Impulse);
        return;
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
