// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
/// <summary>
/// Manages various UI Menus
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;

    private void Start()
    {       
        // Subscribe / Listen to the GameManager EventGameState OnGameStateChanged event  
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }
    /// <summary>
    /// Handles what happens when the UIManager is notified of a GameState change.
    /// Arguements taken in are the EventArgs Parameters
    /// </summary>
    /// <param name="currentState"></param>
    /// <param name="previousState"></param>
    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState) 
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            _pauseMenu.gameObject.SetActive(false);
            _gameOverMenu.gameObject.SetActive(false);
            return;
        }

        if(currentState == GameManager.GameState.PAUSED)
        {
            _pauseMenu.gameObject.SetActive(true);
            return;
        }
        if(currentState == GameManager.GameState.GAMEOVER)
        {
            _gameOverMenu.gameObject.SetActive(true);
            return;
        }

        // <-----> Another way to implement using switch
        //switch (currentState)
        //{
        //    case GameManager.GameState.RUNNING:
        //        _pauseMenu.gameObject.SetActive(false);
        //        _gameOverMenu.gameObject.SetActive(false);
        //        break;
        //    case GameManager.GameState.PAUSED:    
        //        _pauseMenu.gameObject.SetActive(true);
        //        break;
        //    case GameManager.GameState.GAMEOVER:              
        //        break;
        //    default:
        //        _pauseMenu.gameObject.SetActive(false);
        //        break;
        //}
    }

}
