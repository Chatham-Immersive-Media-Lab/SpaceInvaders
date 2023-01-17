// ----------------------------------------------------------------------------
//  Chatham University
//  Week 3
//  JANUARY 2023
// ----------------------------------------------------------------------------
using UnityEngine;
/// <summary>
/// GMData stores any data you would like to persist through out the life cycle of the game
/// </summary>
[CreateAssetMenu(fileName = "newGameManagerData", menuName = "GameManager/GameData")]
public class GMData : ScriptableObject
{
    /// <summary>
    /// The persistent stored value of the GameManager State
    /// </summary>
    public GameManager.GameState CurrentGameState;

    private int highScore;

    public void SetHighScore(int value)
    {
        highScore = value;
    }
}
