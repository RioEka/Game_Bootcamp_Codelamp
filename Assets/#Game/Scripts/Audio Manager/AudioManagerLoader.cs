using UnityEngine;


//taruh script ini 
public class AudioManagerLoader : MonoBehaviour
{
    private void Awake()
    {
        if (AudioManager.Instance == null)
        {
            //cari prefab dari folder Resources
            GameObject audioManagerPrefab = Resources.Load<GameObject>("AudioManager");
            if (audioManagerPrefab != null)
            {
                Instantiate(audioManagerPrefab);
            }
            else
            {
                Debug.LogError("AudioManager prefab tidak ditemukan di Resources");
            }
        }
    }
}
