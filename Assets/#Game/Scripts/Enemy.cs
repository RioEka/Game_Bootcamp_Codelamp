using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform pointA; // Titik patroli A
    [SerializeField] private Transform pointB; // Titik patroli B

    [Header("Enemy Settings")]
    [SerializeField] private float speed = 2f; // Kecepatan gerak musuh

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Transform currentTarget;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // Mulai dengan bergerak menuju titik A
        currentTarget = pointA;
    }

    void Update()
    {
        // Cek apakah musuh sudah dekat dengan target
        if (Vector2.Distance(transform.position, currentTarget.position) < 1f)
        {
            // Jika target saat ini adalah A, ganti target ke B
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            // Jika target saat ini adalah B, ganti target ke A
            else
            {
                currentTarget = pointA;
            }
        }
    }

    void FixedUpdate()
    {
        // Hitung arah menuju target
        Vector2 direction = (currentTarget.position - transform.position).normalized;

        // Beri kecepatan pada musuh untuk bergerak ke arah target
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        // Balikkan sprite sesuai arah kecepatan
        if (rb.velocity.x > 0.1f)
        {
            sprite.flipX = true; // Menghadap ke kanan
        }
        else if (rb.velocity.x < -0.1f)
        {
            sprite.flipX = false; // Menghadap ke kiri
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang ditabrak adalah pemain
        if (collision.gameObject.CompareTag("Player"))
        {
            DeathCountManager.Instance.AddDeath();
            // Ambil komponen PlayerRespawn dari objek pemain
            PlayerRespawn playerRespawn = collision.gameObject.GetComponent<PlayerRespawn>();

            // Jika pemain memiliki skrip tersebut, panggil fungsi Respawn()
            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
        }
    }

}