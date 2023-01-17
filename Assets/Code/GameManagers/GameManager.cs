// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// GameManager manages all game systems
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// This is our ScriptableObject that serves as a container for our GameManager
    /// </summary>
    [Header("GameManager ScriptedAsset")]
    public GMData GMData;

    /// <summary>
    /// Enum to store our game manager instances state
    /// </summary>
    public enum GameState
    {
        RUNNING,
        PAUSED,
        SCENECHANGE,
        GAMEOVER
    }
    public SceneController sceneController;

    /// <summary>
    /// Event that will notify all subscribers of the GameStateChange Event.
    /// </summary>
    public EventGameState OnGameStateChanged;
    /// <summary>
    /// GameState enum to store GameState
    /// </summary>
    GameState _currentGameState = GameState.RUNNING;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }
    /// <summary>
    /// Execute after Awake and before first Update. Init Here!
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(gameObject); // Tells Unity that we do not want to destroy this GameObject on Scene Load
        GMData.CurrentGameState = _currentGameState; // Set the GameManager state to the stores state in GMData
        sceneController.onSceneChangeStart.AddListener(HandleSceneChangeStart); // Subscribe or Listen for EventSceneChangeStart
        sceneController.onSceneChangeComplete.AddListener(HandleSceneChangeComplete);// Subscribe or Listen for EventSceneChangeComplete
        OnGameStateChanged.Invoke(GMData.CurrentGameState, _currentGameState); // Let ALL other components listening for EventGameStateChange that the GameState has changed
    }
    /// <summary>
    /// Called every frame.
    /// </summary>
    void Update()
    {
        // If scene is changing return
        if (_currentGameState == GameState.SCENECHANGE)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    /// <summary>
    /// Updates GameState. Is call when another script triggers a state change. Can also be called directly.
    /// </summary>
    /// <param name="state"></param>
    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState; // store previous state
        _currentGameState = state; // set current state to the new state
        GMData.CurrentGameState = _currentGameState; // store the current state in our persistent data container

        // Switch to handle what needs to execute for each state 
        switch (CurrentGameState)
        {
            case GameState.SCENECHANGE:
                // Initialize any systems that need to be reset
                Debug.Log("Scene Changing");
                Time.timeScale = 1.0f; // Time.timeScale will slow down time or bring it to a complete stop. 
                break;

            case GameState.RUNNING:
                //  Unlock player, enemies and input in other systems, update tick if you are managing time
                Debug.Log("Game Running");
                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:
                // Pause player, enemies etc, Lock other input in other systems
                Debug.Log("Game Paused");
                Time.timeScale = 0.0f; // Time.timeScale will stop the game. Paused!
                break;
            case GameState.GAMEOVER:
                // Implement Actions like - Pause player, enemies etc, Lock other input in other systems. 
                Debug.Log("Game Over");
                Time.timeScale = 1.0f;
                break;

            default:
                break;
        }
        // When this executes it will Notify ALL Scripts that are subscribed or listening for the EventGameState
        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }
    /// <summary>
    /// Toggles between the PAUSED State and the RUNNING State
    /// </summary>
    public void TogglePause()
    {
        //The ? conditional operator commonly known as the ternary conditional operator, returns one of two values depending on the value of a Boolean expression.
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
        // Verbose version of the code above.
        //if (_currentGameState == GameState.RUNNING)
        //    UpdateState(GameState.PAUSED);
        //else
        //    UpdateState(GameState.RUNNING);
    }
    /// <summary>
    /// Loads the first game level
    /// </summary>
    public void StartGame()
    {
        /// This can be implemented with a Dictionary, or many other more robust ways.
        sceneController.FadeAndLoadScene(sceneController.Scenes[1].sceneInfo.sceneName);
        // <-----> Simple way using stored variable declared above, prone to error if string value is a typo
        // sceneController.FadeAndLoadScene(gameScene);

        // <-----> Hard coded way prone to error if string value is a typo
        // sceneController.FadeAndLoadScene("gameScene");

    }
    /// <summary>
    /// Restarts the current level
    /// </summary>
    public void RestartLevel()
    {
        sceneController.FadeAndLoadScene(sceneController.CurrentScene);
    }
    /// <summary>
    /// Quits the game and changes the scene to the TitleMenu
    /// </summary>
    public void QuitToTitle()
    {
        sceneController.FadeAndLoadScene(sceneController.Scenes[0].sceneInfo.sceneName);

        // <-----> Simple way using stored variable declared above, prone to error if string value is a typo
        // sceneController.FadeAndLoadScene(titleScene);

        // <-----> Hard coded way prone to error if string value is a typo
        // sceneController.FadeAndLoadScene("TitleScene");
    }
    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        //These are called regions. When the C# compiler encounters an #if directive, 
        //  followed eventually by an #endif directive, it compiles the code between the 
        //  directives only if the specified symbol is defined. 
#if UNITY_STANDALONE //If we are running in a standalone build of the game
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene.
        UnityEditor.EditorApplication.isPlaying = false;
#endif      
    }
    /// <summary>
    /// When the event EventSceneChangeStart fires, this method is executed.
    /// </summary>
    /// <param name="started"></param>
    public void HandleSceneChangeStart(bool started)
    {
        Debug.Log("[GameManager] Scene Change Start.");
        UpdateState(GameState.SCENECHANGE);
    }
    /// <summary>
    /// When the event EventSceneChangeComplete fires, this method is executed.
    /// </summary>
    public void HandleSceneChangeComplete(bool complete)
    {
        Debug.Log("[GameManager] Scene Change Complete."); 
        UpdateState(GameState.RUNNING); // The Scene change is complete so set the game state to run.
    }
    /// <summary>
    /// Subclass EventGameState using scoped enum.  
    /// </summary>
    [System.Serializable] public class EventGameState : UnityEvent<GameState, GameState> { }
}
