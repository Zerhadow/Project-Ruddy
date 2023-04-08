using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerF : MonoBehaviour
{
    private Rigidbody rb;

    #region Stats & Cooldowns
    public int ATK;
    public float moveSpeed = 5f;
    public float fireCooldown = 0.3f;
    public float meleeRange = 0.5f;
    #endregion

    bool canFire = true, canMove = true, evaded = false;
    bool blocked = false;

    public PlayerInputActions playerControls;
    private PlayerInput playerInput;
    Vector3 lookDirection = new Vector3(1,0,0);
    public Vector2 MoveInput { get; private set; } = Vector2.zero;

    #region #Input Actions
    private InputAction move;
    private InputAction fire;
    // private InputAction melee;
    // private InputAction pause;
    // private InputAction talk;
    #endregion

    public GameObject projectilePrefab;
    public Transform atkPt;

    void Awake() {
        playerControls = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        playerControls.Player.Enable();
        rb = GetComponent<Rigidbody>();

        // dmg = ATK;
    }

    // Start is called before the first frame update
    void Start() {
        // currHP = maxHP;
        // // Debug.Log("currHP: " + currHP);        
        // HPBar.SetMaxHealth(maxHP);
    }

    private void OnEnable() {
        playerControls.Player.Move.performed += setMove;
        playerControls.Player.Move.canceled += setMove;

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        // melee = playerControls.Player.Melee;
        // melee.Enable();
        // melee.performed += Melee;

        // pause = playerControls.Player.Pause;
        // pause.Enable();
        // pause.performed += Pause;
    }

    private void OnDisable() {
        playerControls.Player.Move.performed -= setMove;
        playerControls.Player.Move.canceled -= setMove;
        
        fire.Disable();
        // melee.Disable();
        // pause.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (MoveInput != Vector2.zero) {
            lookDirection = rb.velocity;
            lookDirection.Normalize();
        }

    }

    void FixedUpdate() {
        
    }

    void setMove(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }

    void Move() {
        if (canMove) {
            rb.velocity = new Vector3(MoveInput.x * moveSpeed, 0, MoveInput.y * moveSpeed);
        }
    }

    private void Fire(InputAction.CallbackContext context) {
        if (canFire) {
            Debug.Log("Fire");
            StartCoroutine(FireCooldown(fireCooldown));
            GameObject projectileObj = Instantiate(projectilePrefab, rb.position, Quaternion.identity); //may need to change to rb.position
            Projectile projectile = projectileObj.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            //particles
        }
    }

    IEnumerator FireCooldown(float timer) {
        canFire = false;
        while(timer > 0) {
            timer -= Time.deltaTime;
            yield return null;
        }
        canFire = true;
    }
}
