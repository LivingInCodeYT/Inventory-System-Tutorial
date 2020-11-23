using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Movement : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator a;

    private float horizontal;
    private bool isGrounded;

    public float moveSpeed = 3f;
    public float jumpForce = 8f;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsJumpable;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
    }
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsJumpable);
        #region Sprite Flip
        if (horizontal != 0f) {
            if (horizontal < 0f) {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } else {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        #endregion
        #region Animation Control
        if (horizontal != 0f) {
            a.Play("run");
        } else {
            a.Play("idle");
        }
        if (!isGrounded) {
            if (rb.velocity.y >= 0f) {
                a.Play("jump_climb");
            } else {
                a.Play("jump_fall");
            }
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (isGrounded) {
                Jump();
            }
        }
    }
    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
    }
    void Jump() {
        isGrounded = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}