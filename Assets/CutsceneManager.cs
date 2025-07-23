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

    private const string cutsceneKey = "HasSeenIntroCutscene";

    private void Start()
    {
        Debug.Log("CutsceneManager Started");

        // Hanya untuk testing di Editor: reset key biar cutscene muncul terus
        #if UNITY_EDITOR
        PlayerPrefs.DeleteKey(cutsceneKey);
        #endif

        if (PlayerPrefs.HasKey(cutsceneKey))
        {
            Debug.Log("Cutscene already played. Skipping...");
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        Debug.Log("Playing cutscene...");
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        PlayerPrefs.SetInt(cutsceneKey, 1);

        for (int i = 0; i < cutsceneSlides.Length; i++)
        {
            cutsceneImage.sprite = cutsceneSlides[i];

            // Fade In
            yield return StartCoroutine(FadeCanvas(0f, 1f));

            // Wait
            yield return new WaitForSeconds(slideDuration);

            // Fade Out
            yield return StartCoroutine(FadeCanvas(1f, 0f));
        }

        // Load next scene
        SceneManager.LoadScene(nextSceneName);
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
}
