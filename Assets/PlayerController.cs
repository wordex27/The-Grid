using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public float speed = 5f;

    public DialogueUI DialogueUI =>  dialogueUI;

    public Interactible Interactible { get; set; }


    public float jumpForce = 10f; 
    public bool isGrounded;

    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        if (dialogueUI.isOpen)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        } 
        float xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
    }

    void Update()
    {

        if (dialogueUI.isOpen) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);   
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Interactible?.Interact(player:this);
        }
    }

}
