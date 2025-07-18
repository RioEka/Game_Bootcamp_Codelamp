using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Whiskas : MonoBehaviour
{
    [SerializeField] private float timeBonus = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            AudioManager.Instance.PlayPowerup();

            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.AddTime(timeBonus);
                Debug.Log($"Whiskas powerup collected! add{timeBonus} seconds");
            }

            Destroy(gameObject);
        }
    }
}
