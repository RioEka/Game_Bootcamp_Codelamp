using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("------- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource walkingSource;

    [Header("------- Music------- ")]
    public AudioClip bgm;

    [Header("------- Audio Clip ------")]
    //public AudioClip background;
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
        //singelton setup
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
        //daftar event listener untuk sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        //unsubscribe biar gak error saat destroy
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //saat masuk ke main menu, stop semua suara jalan
        if (scene.name == "MainMenu")
        {
            StopWalking();
            StopBGM();
            
            //biar sfx nya nyala lagi
            SFXSource.mute = false;
            SFXSource.volume = 1f;
        }
        //ini nama game scene nya depannya harus "Level"
        else if (scene.name.StartsWith("Level"))
        {
            if (!musicSource.isPlaying)
            {
                PlayBGM();
            }

        }
    }

    //Musik BGM
    public void PlayBGM()
    {
        if (bgm == null)
        {
            //Debug.LogWarning("BGM clip belum diassign!");
            return;
        }

        musicSource.clip = bgm;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopBGM()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    //SFX
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            Debug.Log("Playing SFX: " + clip.name + " | Source Volume: " + SFXSource.volume + " | Mute: " + SFXSource.mute);
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
    public void PlayJump()=> PlaySFX(jump);
    public void PlayClick() => PlaySFX(click);
    public void PlayWin() => PlaySFX(win);
    public void PlayLost() => PlaySFX(lost);

    //Walking
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
