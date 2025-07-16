<<<<<<< Updated upstream
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> Stashed changes
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
<<<<<<< Updated upstream
    private Vector3 respawnPoint; // Variabel untuk menyimpan posisi respawn

    void Start()
    {
        // Saat game dimulai, simpan posisi awal sebagai titik respawn pertama
        respawnPoint = transform.position;
    }

    // Fungsi ini akan dipanggil oleh musuh atau rintangan
    public void Respawn()
    {
        // Pindahkan posisi pemain kembali ke titik respawn
        transform.position = respawnPoint;

        // Opsional: Reset kecepatan agar tidak meluncur setelah respawn
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Fungsi ini mendeteksi jika pemain menyentuh checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah objek yang disentuh memiliki tag "Checkpoint"
        if (collision.CompareTag("Checkpoint"))
        {
            // Perbarui titik respawn ke posisi checkpoint
            respawnPoint = collision.transform.position;

            // Opsional: Hancurkan checkpoint agar tidak bisa digunakan lagi
            // atau mainkan suara/efek untuk memberi tahu pemain.

            Debug.Log("Checkpoint Reached! New respawn point set.");
        }
    }
}
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> Stashed changes
