using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//ini buat ngatur sistem death counts nya
public class DeathCountManager : MonoBehaviour
{
    public static DeathCountManager Instance;

    public int deathCount = 0;
    [SerializeField] private TextMeshProUGUI deathText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddDeath()
    {
        deathCount++;
        deathText.text = $"Deaths: {deathCount}";
    }

    public int GetDeathCount()
    {
        return deathCount;
    }
}

//tambahin ini di setiap konsisi mati: GameStatsManager.Instance.AddDeath();