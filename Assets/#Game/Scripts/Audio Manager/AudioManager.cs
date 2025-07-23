using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("------- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource walkingSource;

    [Header("------- Music -------")]
    public AudioClip bgm; // untuk Level
    [Tooltip("Digunakan untuk MainMenu dan Cutscene")]
    public AudioClip menuAndCutsceneBGM;

    [Header("------- Audio Clip ------")]
    public AudioClip damage;
    public AudioClip key;
    public AudioClip powerup;
    public AudioClip walking;
    public AudioClip jump;
    public AudioClip click;
    public AudioClip win;
    public AudioClip lost;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopWalking();
        UpdateBGMForScene(scene.name);
    }

    private void UpdateBGMForScene(string sceneName)
    {
        sceneName = sceneName.ToLower();

        if (sceneName == "mainmenu" || sceneName.Contains("cutscene"))
        {
            if (musicSource.clip != menuAndCutsceneBGM)
            {
                musicSource.clip = menuAndCutsceneBGM;
                musicSource.loop = true;
                musicSource.Play();
            }

            SFXSource.mute = false;
            SFXSource.volume = 1f;
        }
        else if (sceneName.StartsWith("level"))
        {
            if (bgm != null)
            {
                if (musicSource.clip != bgm)
                {
                    musicSource.clip = bgm;
                    musicSource.loop = true;
                }

                if (!musicSource.isPlaying)
                {
                    musicSource.Play();
                }
            }
        }
    }

    public void PlayBGM()
    {
        if (bgm == null) return;

        if (musicSource.clip != bgm)
        {
            musicSource.clip = bgm;
            musicSource.loop = true;
        }

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopBGM()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            Debug.Log("Playing SFX: " + clip.name + " | Volume: " + SFXSource.volume + " | Mute: " + SFXSource.mute);
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Clip SFX kosong!");
        }
    }

    public void PlayDamage() => PlaySFX(damage);
    public void PlayKey() => PlaySFX(key);
    public void PlayPowerup() => PlaySFX(powerup);
    public void PlayWalking() => PlaySFX(walking);
    public void PlayJump() => PlaySFX(jump);
    public void PlayClick() => PlaySFX(click);
    public void PlayWin() => PlaySFX(win);
    public void PlayLost() => PlaySFX(lost);

    public void StartWalking()
    {
        if (!walkingSource.isPlaying && walking != null)
        {
            walkingSource.clip = walking;
            walkingSource.loop = true;
            walkingSource.Play();
        }
    }

    public void StopWalking()
    {
        if (walkingSource.isPlaying)
        {
            walkingSource.Stop();
        }
    }
}
