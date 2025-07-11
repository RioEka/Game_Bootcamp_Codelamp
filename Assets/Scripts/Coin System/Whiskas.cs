using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Whiskas : MonoBehaviour, ICollectible
{
    public static event Action OnWhiskasCollected;

    public void Collect()
    {
        OnWhiskasCollected?.Invoke();
        Debug.Log("whiskas collected!");
        Destroy(gameObject);
    }
}
