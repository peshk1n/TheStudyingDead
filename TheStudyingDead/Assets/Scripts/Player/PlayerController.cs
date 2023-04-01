using UnityEditor.Animations;
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
    [SerializeField] private AnimatorController _armed;
    [SerializeField] private AnimatorController _unarmed;


    private PlayerInput _playerInput;
    private string _directionState = RIGHT;
    private Animator _animatorController;
    private bool _isArmed = false;

    private PlayerMover _playerMover;
    private PlayerInteraction _playerInteraction;

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


        _animatorController = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _playerMover.Move(moveDirection);
    }

    public void OnInteract()
    {
        _playerInteraction.Interact();
    }

    public void OnLanternEnable()
    {
        if (_lantern.IsEnabled)
            _lantern.TurnOff();
        else
            _lantern.TurnOn();
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
        if (!_isArmed)
            return;
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