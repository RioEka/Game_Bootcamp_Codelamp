using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Control : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public float jumpForce = 5f;
    private Vector2 movement;
    private Animator anim;
    private SpriteRenderer flip;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        //set run untuk transisi animasi
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * moveSpeed));

        // Flip karakter
        if (movement.x > 0) flip.flipX = false;
        else if (movement.x < 0) flip.flipX = true;

        // Cek loncat
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("IsJumping", !isGrounded);

        // Tombol lompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            var xMovement = movement.x * moveSpeed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0));
        }
    }
}
