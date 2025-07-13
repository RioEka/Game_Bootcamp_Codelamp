using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject LevelSelection;
    [SerializeField] GameObject Credits;

    public void OpenMainMenu()
    {
        closeAllMenus();
        mainMenu.SetActive(true);
    }
    public void OpenSettingsMenu()
    {
        closeAllMenus();
        settingsMenu.SetActive(true);
    }
    public void OpenLevelSelection()
    {
        closeAllMenus();
        LevelSelection.SetActive(true);
    }
    public void OpenCredits()
    {
        closeAllMenus();
        Credits.SetActive(true);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
    private void closeAllMenus()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        LevelSelection.SetActive(false);
        Credits.SetActive(false);
    }
}