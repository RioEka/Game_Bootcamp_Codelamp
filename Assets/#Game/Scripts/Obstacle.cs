using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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