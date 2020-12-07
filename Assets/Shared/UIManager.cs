using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject ADpanel;

    private void Start()
    {
        AdsManager.ReviveEvent += DisableADpanel;
        AdsManager.ReviveEvent += DisablePanel;
    }

    private void OnDisable()
    {
        AdsManager.ReviveEvent -= DisableADpanel;
        AdsManager.ReviveEvent -= DisablePanel;
    }
    public void RestartGame()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnablePanel()
    {
        panel.SetActive(true);
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
    }

    public void EnableADpanel()
    {
        ADpanel.SetActive(true);
    }

    public void DisableADpanel()
    {
        ADpanel.SetActive(false);
    }
}
