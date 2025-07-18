using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key : MonoBehaviour, ICollectible
{
    public static event Action OnKeyCollected;

    public void Collect()
    {
        AudioManager.Instance.PlayKey();

        OnKeyCollected?.Invoke();
        Debug.Log("Key collected!");
        Destroy(gameObject);
    }
}
