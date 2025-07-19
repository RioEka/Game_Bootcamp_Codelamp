using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject LevelSelection;
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject Bg;

    public void OpenMainMenu()
    {
        AudioManager.Instance?.PlayClick();
        closeAllMenus();
        mainMenu.SetActive(true);
        Bg.SetActive(true);
    }
    public void OpenSettingsMenu()
    {
        AudioManager.Instance?.PlayClick();
        closeAllMenus();
        settingsMenu.SetActive(true);
    }
    public void OpenLevelSelection()
    {
        AudioManager.Instance?.PlayClick();
        closeAllMenus();
        LevelSelection.SetActive(true);
    }
    public void OpenCredits()
    {
        AudioManager.Instance?.PlayClick();
        closeAllMenus();
        Credits.SetActive(true);
    }
    public void CloseApp()
    {
        AudioManager.Instance?.PlayClick();
        Application.Quit();
    }
    private void closeAllMenus()
    {
        AudioManager.Instance?.PlayClick();
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        LevelSelection.SetActive(false);
        Credits.SetActive(false);
        Bg.SetActive(false);
    }

    public void LoadLevels(string sceneName)
    {
        AudioManager.Instance?.PlayClick();
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f; //
        
    }
}