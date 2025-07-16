using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public float jumpForce = 5f;
    // Variabel untuk mengontrol gravitasi saat jatuh
    public float fallMultiplier = 2.5f;

    private Vector2 movement;
    private Animator anim;
    private SpriteRenderer flip;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    // Variabel untuk menyimpan gravitasi dasar
    private float baseGravityScale;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        // Simpan nilai gravitasi awal dari Rigidbody2D
        baseGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        // Set run untuk transisi animasi
        anim.SetFloat("Speed", Mathf.Abs(movement.x * moveSpeed));

        // Flip karakter
        if (movement.x > 0) flip.flipX = false;
        else if (movement.x < 0) flip.flipX = true;

        // Cek daratan
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("IsJumping", !isGrounded);

        // Tombol lompat DITEKAN (memulai lompatan)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // >> LOGIKA VARIABLE JUMP DITAMBAHKAN DI SINI <<
        // Jika tombol lompat DILEPAS saat sedang naik, potong ketinggian lompatan
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        // 1. Gerakan Player menggunakan velocity
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // 2. Logika Faster Fall
        if (rb.velocity.y < 0)
        {
            // Saat jatuh, tingkatkan gravitasi
            rb.gravityScale = baseGravityScale * fallMultiplier;
        }
        else
        {
            // Saat naik atau di darat, kembalikan gravitasi ke normal
            rb.gravityScale = baseGravityScale;
        }
    }
}