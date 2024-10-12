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
        // 마우스의 위치가 들어오는 OnLookEvent에 등록
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateSprite(newAimDirection);
    }

    private void RotateSprite(Vector2 direction)
    {
        // 캐릭터가 바라보는 방향 각도 구하기
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 각도에 맞춰 캐릭터 뒤집기
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}