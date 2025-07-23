using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    [Header("Cutscene Settings")]
    public Sprite[] cutsceneSlides;
    public float slideDuration = 3f;
    public float fadeDuration = 1f;
    public string nextSceneName = "MainMenu";

    [Header("UI References")]
    public Image cutsceneImage;
    public CanvasGroup canvasGroup;
    public Button skipButton;

    private bool isSkipping = false;

    private void Start()
    {
        skipButton.onClick.AddListener(SkipCutscene);
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        for (int i = 0; i < cutsceneSlides.Length; i++)
        {
            if (isSkipping) yield break;

            cutsceneImage.sprite = cutsceneSlides[i];

            yield return StartCoroutine(FadeCanvas(0f, 1f));

            float timer = 0f;
            while (timer < slideDuration)
            {
                if (isSkipping) yield break;
                timer += Time.deltaTime;
                yield return null;
            }

            yield return StartCoroutine(FadeCanvas(1f, 0f));
        }

        if (!isSkipping)
        {
            LoadNextScene();
        }
    }

    IEnumerator FadeCanvas(float from, float to)
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
    }

    public void SkipCutscene()
    {
        if (isSkipping) return;
        isSkipping = true;
        StopAllCoroutines();
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
