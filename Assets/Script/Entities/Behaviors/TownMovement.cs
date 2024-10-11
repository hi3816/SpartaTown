using UnityEngine;
using UnityEngine.UIElements;
// TownMovement는 캐릭터와 몬스터의 이동에 사용될 예정입니다.
public class TownMovement : MonoBehaviour
{
    private TownController movementController;
    private Rigidbody2D movementRigidbody;
    [SerializeField] private SpriteRenderer characterRenderer;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 aimDirection = Vector2.right;

    private void Awake()
    {
        // 같은 게임오브젝트의 TownController, Rigidbody를 가져올 것 
        movementController = GetComponent<TownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent에 Move를 호출하라고 등록함
        movementController.OnMoveEvent += Move;
        // OnLookEvent에 OnAim를 호출하라고 등록함
        movementController.OnLookEvent += OnAim;
    }

    private void FixedUpdate()
    {
        // 물리 업데이트에서 움직임 적용
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // 이동방향만 정해두고 실제로 움직이지는 않음.
        // 움직이는 것은 물리 업데이트에서 진행(rigidbody가 물리니까)
        movementDirection = direction;
    }

    private void OnAim(Vector2 aimDirection)
    {
        //rotZ 은 direction 벡터가 원점으로부터 형성하는 각도
        float rotZ = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;

        movementRigidbody.velocity = direction;
    }
}
