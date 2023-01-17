// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button RetryButton;
    public Button QuitToTitleButton;

    private void Awake()
    {
        RetryButton.onClick.AddListener(HandleRetryClick);
        QuitToTitleButton.onClick.AddListener(HandleQuitClick);
    }

    void HandleRetryClick()
    {
        GameManager.Instance.RestartLevel();
    }

    void HandleQuitClick()
    {
        GameManager.Instance.QuitToTitle();
    }
}
