// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls basic Scene Management functions
/// </summary>
public class SceneController : MonoBehaviour 
{
    /// <summary>
    /// Array of SceneItems used to refered scenes loaded into the build index
    /// </summary>
    public List<SceneAsset> Scenes;
    /// <summary>
    /// CanvasGroup that has the Alpha we minipulate to create the "fade" effect
    /// </summary>
    public CanvasGroup screenFadeCanvas;
    /// <summary>
    /// How long in seconds the screen fades from transparent to black.
    /// </summary>
    public float fadeDuration = 1f;
    /// <summary>
    /// Current Name of the Scene that is loaded
    /// </summary>
    [SerializeField]
    private string currentScene;
    public string CurrentScene
    {
        get { return currentScene; }
        private set { currentScene = value; }
    }
    /// <summary>
    /// Bool check to make sure try to FadeAndLoad a scene while still in the fading sequence.
    /// </summary>
    private bool isFading;
    /// <summary>
    /// Event that will notify all subscribers that the SceneChange sequence has started
    /// </summary>
    public Events.EventFadeComplete onSceneChangeStart;
    /// <summary>
    /// Event that will notify all subscribers that the SceneChange sequence has completed
    /// </summary>
    public Events.EventFadeComplete onSceneChangeComplete;
    /// <summary>
    /// Starts the Fade and Switch Coroutine
    /// </summary>
    /// <param name="sceneName"></param>
    public void FadeAndLoadScene(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneName));
        }
    }
    /// <summary>
    /// Calls Coroutine Fade to black, async loads scene then fades away from black.
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(Fade(1f));
        yield return SceneManager.LoadSceneAsync(sceneName);
        onSceneChangeStart.Invoke(true);
        yield return StartCoroutine(Fade(0f));
        onSceneChangeComplete.Invoke(true);
        currentScene = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// Adjusts the CanvasGroup Component Alpha creating a "Screen Fade" effect.
    /// </summary>
    /// <param name="finalAlpha"></param>
    /// <returns></returns>
    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;
        screenFadeCanvas.blocksRaycasts = true; // Blocks player Clicking on other Scene or UI GameObjects
        float fadeSpeed = Mathf.Abs(screenFadeCanvas.alpha - finalAlpha) / fadeDuration;
        while (!Mathf.Approximately(screenFadeCanvas.alpha, finalAlpha))
        {
            screenFadeCanvas.alpha = Mathf.MoveTowards(screenFadeCanvas.alpha, finalAlpha,
                fadeSpeed * Time.deltaTime);
            yield return null; //Lets the Coroutine finish
        }
        isFading = false;
        screenFadeCanvas.blocksRaycasts = false;
    }
}