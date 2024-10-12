using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    private CreatureController movementController;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        movementController = GetComponent<CreatureController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent�� Move�� ȣ���϶�� ���
        movementController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // ���� ������Ʈ���� ���� �̵�
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // �̵����⸸ ���صΰ� ���� �̵� X
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;

        movementRigidbody.velocity = direction;
    }
}