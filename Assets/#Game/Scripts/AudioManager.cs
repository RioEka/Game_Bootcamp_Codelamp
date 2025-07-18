using Unity.VisualScripting;
using UnityEngine;

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

        PlayBGM();

    }

    private void Start()
    {
        if (!musicSource.isPlaying)
        {
            PlayBGM();
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

    //SFX
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
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

    public void StopBGM()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

}
