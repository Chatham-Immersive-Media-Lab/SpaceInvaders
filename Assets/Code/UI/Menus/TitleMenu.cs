// ----------------------------------------------------------------------------
//  University of Pittsburgh 
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Implements TitleMenu behaviours
/// </summary>
public class TitleMenu : MonoBehaviour {
    public Button StartGameButton;
    public Button QuitButton;

    private void Awake()
    {
        // Subscribe / Listen for the onClick Button Event and execute HandleResumeClick method when heard / notified
        StartGameButton.onClick.AddListener(HandleResumeClick);
        // Subscribe / Listen for the onClick Button Event and execute HandleQuitClick method when heard / notified
        QuitButton.onClick.AddListener(HandleQuitClick);
    }
    /// <summary>
    /// Handler for the ResumeButton onClick event
    /// </summary>
    void HandleResumeClick()
    {
        GameManager.Instance.StartGame();
    }
    /// <summary>
    /// Handler for the ResumeButton onClick event
    /// </summary>
    void HandleQuitClick()
    {
        GameManager.Instance.QuitGame();
    }
}
