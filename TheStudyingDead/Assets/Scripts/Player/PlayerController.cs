using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Lantern _lantern;
    [SerializeField] private InventoryAnimatedWindow _inventoryWindow;
    [SerializeField] private MenuAnimatedWindow _menuWindow;


    private PlayerInput _playerInput;
    private string _directionState = RIGHT;
    private Animator _animatorController;

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
        _inventoryWindow.OpenNotebook();
    }

    public void OnOpenMenu()
    {
        _inventoryWindow.CloseNotebook();
        _menuWindow.OpenMenu();
    }
}