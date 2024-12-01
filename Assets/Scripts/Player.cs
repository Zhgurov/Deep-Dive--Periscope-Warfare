using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerShoot))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float speedRotate;
    [SerializeField] private Camera playerCamera;

    private InputSystem_Actions action;
    private InputAction movement;
    private InputAction verticalMovement;
    private InputAction horizontalMovement;
    private PlayerShoot playerShoot;
    private PlayerHealth playerHealth;
    private bool isShoot;
    private SpawnItems spawnItems;
    //private bool isMovement;

    public PlayerHealth GetPlayerHealth() => playerHealth;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerShoot = GetComponent<PlayerShoot>();
        playerHealth = GetComponentInChildren<PlayerHealth>();
        spawnItems = FindAnyObjectByType<SpawnItems>();
    }

    private void OnEnable()
    {
        action = new InputSystem_Actions();
        action.Enable();
        movement = action.Player.Move;
        verticalMovement = action.Player.MoveVertical;
        /*verticalMovement.performed += ctx => isMovement = true;
        verticalMovement.canceled += ctx => isMovement = false;*/
        action.Player.Shoot.performed += ctx => isShoot = true;
        action.Player.Shoot.canceled += ctx => isShoot = false;
        action.Player.ShootTorpeda.performed += ctx => playerShoot.ShootTorpeda();
    }

    private void FixedUpdate()
    {
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float vertical = movement.ReadValue<Vector2>().y;
            float horizontal = movement.ReadValue<Vector2>().x;
            transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, horizontal * speedRotate); 
            float verticalM = verticalMovement.ReadValue<Vector2>().y;
            transform.Translate(Vector3.down * verticalM * verticalSpeed * Time.deltaTime);

            /*
            vertical = Mathf.Clamp(verticalRotate, -1, 1);

            transform.Rotate(Vector3.forward, verticalRotate * speedVerticalRotate * Time.deltaTime);
            /*
            float horizontalRotate = horizontalMovement.ReadValue<Vector2>().y;
            horizontalRotate = Mathf.Clamp(horizontalRotate, -80, 70);
            transform.Rotate(Vector3.right, horizontalRotate * speedHorizontalRotate * Time.deltaTime);*/
        }

        if (isShoot)
            playerShoot.Shoot();

        if (Keyboard.current.escapeKey.isPressed)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        /* if (isMovement)
             playerCamera.transform.DOShakePosition(0.5f, 3f, 20, 90f, false, true, ShakeRandomnessMode.Full).SetEase(Ease.InOutElastic);*/

    }
}
