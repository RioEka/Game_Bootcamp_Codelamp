using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultWindowController : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite fullstar, emptyStar;
    [SerializeField] private TMP_Text headerText;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    public void ShowResult(float remainingTime, int deathCount, bool isWin)
    {
        int starCount = 0;

        if (isWin)
        {
            starCount = 1;

            if (remainingTime > 10 && deathCount < 5)
                starCount = 2;

            if (remainingTime > 15 && deathCount == 0)
                starCount = 3;
        

            headerText.text = "You Did It!";
            nextButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(false);
        }
        else
        {
            headerText.text = "Nice Try!";
            nextButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = (i < starCount) ? fullstar : emptyStar;
        }

        resultPanel.SetActive(true);
        Time.timeScale = 0f;//not really sure tapi katanya biar gamenya kepause

    }

    //Not really sure (i suppose it has to be written from the scene name?) imma check later
    public void OnNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
