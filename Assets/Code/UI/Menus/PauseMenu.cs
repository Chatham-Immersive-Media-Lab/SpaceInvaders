// ----------------------------------------------------------------------------
// Author:  William O'Toole
// Project: BitRivet Framework
// Date:    13 JUNE 2018
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    public Button ResumeButton;
    public Button QuitButton;

    private void Awake()
    {
        ResumeButton.onClick.AddListener(HandleResumeClick);
        QuitButton.onClick.AddListener(HandleQuitClick);
    }

    void HandleResumeClick()
    {
        GameManager.Instance.TogglePause();
    }

    void HandleQuitClick()
    {
        GameManager.Instance.QuitToTitle();
    }
}
