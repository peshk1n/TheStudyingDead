//using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Lantern _lantern;
    [SerializeField] private InventoryAnimatedWindow _inventoryWindow;
    [SerializeField] private MenuAnimatedWindow _menuWindow;
    [SerializeField] private BoardWindow _boardWindow;
    [SerializeField] private RuntimeAnimatorController _armed;
    [SerializeField] private RuntimeAnimatorController _unarmed;
    [SerializeField] private float _attackDeley;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private string _directionState = RIGHT;
    private Animator _animatorController;
    private bool _isArmed = false;
    private bool _isAttacking = false;

    private PlayerMover _playerMover;
    private PlayerInteraction _playerInteraction;
    private PlayerAttack _playerAttack;

    public bool IsArmed => _isArmed;
    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";
    public string DirectionState { get { return _directionState; } set { _directionState = value; } }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Interact.performed += ctx => OnInteract();
        _playerInput.Player.Lantern.performed += ctx => OnLanternEnable();
        _playerInput.Player.OpenNotebook.performed += ctx => OnOpenNotebook();
        _playerInput.Player.OpenMenu.performed += ctx => OnOpenMenu();
        _playerInput.Player.Attack.performed += ctx => Attack();

        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _playerInteraction = GetComponent<PlayerInteraction>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerMover.Move(Vector2.zero);
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        if (!_isAttacking) {
            Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            _playerMover.Move(moveDirection);
        }
    }

    public void OnInteract()
    {
        _playerInteraction.Interact();
    }

    public void OnLanternEnable()
    {
        if (GetComponent<Inventory>().ContainId("lantern"))
        { if (_lantern.IsEnabled)
                _lantern.TurnOff();
            else
                _lantern.TurnOn();
        }
    }

    public void OnOpenNotebook()
    {
        _menuWindow.Close();
        _boardWindow.Close();
        _inventoryWindow.OpenNotebook();
    }

    public void OnOpenMenu()
    {
        _inventoryWindow.CloseNotebook();
        _boardWindow.Close();
        _menuWindow.OpenMenu();
    }

    public void Attack()
    {
        if (!_isAttacking && _isArmed)
        {
            _isAttacking = true;
            _playerAttack.Attack();
            _rigidbody.velocity = Vector2.zero;
            _animatorController.Play($"Attack Idle {_directionState}");
            //float attackDeley = (float)_animatorController.GetCurrentAnimatorClipInfo(0).Length / 3.0f;
            Invoke("Attack—omplete", _attackDeley);
        }
    }

    private void Attack—omplete()
    {
        _isAttacking = false;
    }

    public void ArmPlayer()
    {
        _isArmed = true;
        _animatorController.runtimeAnimatorController = _armed;
    }

    public void DisarmPlayer()
    {
        _isArmed = false;
        _animatorController.runtimeAnimatorController = _unarmed;
    }
}