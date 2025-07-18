using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    [SerializeField] private float flashDuration = 0.3f;
    [SerializeField] private Color flashColor = new Color(1f, 0f, 0f, 0.4f); // merah semi transparan

    private void Awake()
    {
        if (flashImage != null)
            flashImage.color = Color.clear;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }

    private System.Collections.IEnumerator DoFlash()
    {
        flashImage.color = flashColor;

        float elapsed = 0f;
        while (elapsed < flashDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(flashColor.a, 0f, elapsed / flashDuration);
            flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        flashImage.color = Color.clear;
    }
}
