using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.CompareTag("Player"))
        {
            DeathCountManager.Instance.AddDeath();
            Destroy(gameObject);
        // Reset player ke checkpoint atau restart
        }
}

}
