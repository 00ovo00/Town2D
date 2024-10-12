using UnityEngine;

public class CreatureAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private CreatureController _controller;

    private void Awake()
    {
        _controller = GetComponent<CreatureController>();
    }

    void Start()
    {
        // ���콺�� ��ġ�� ������ OnLookEvent�� ���
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateSprite(newAimDirection);
    }

    private void RotateSprite(Vector2 direction)
    {
        // ĳ���Ͱ� �ٶ󺸴� ���� ���� ���ϱ�
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // ������ ���� ĳ���� ������
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}