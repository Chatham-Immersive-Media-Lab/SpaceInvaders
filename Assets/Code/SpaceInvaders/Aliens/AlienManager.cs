// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AlienManager : MonoBehaviour
{
    [SerializeField] private AlienController[] aliens;
    public Alien AlienPrefab;
    public int AmountOfRows;
    public int AliensPerRow;
    
    public int alienCount;
    public bool WinCondition;
    // Use this for initialization
    void Start ()
    {
        PopulateAliens();
        WinCondition = false;
        aliens = FindObjectsOfType<AlienController>();
        alienCount = aliens.Length;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (WinCondition)
            return;
        if (alienCount <= 0)
        {
            WinCondition = true;
            GameManager.Instance.UpdateState(GameManager.GameState.GAMEOVER);
        }
    }

    private void PopulateAliens()
    {
        for (int i = 0; i < AmountOfRows; i++)
        {
            for (int j = 0; j < AliensPerRow; j++)
            {
                Alien alien = Instantiate(AlienPrefab);
                alien.transform.position = new Vector2(j*2, i + 10);
            }
        }
    }
}
