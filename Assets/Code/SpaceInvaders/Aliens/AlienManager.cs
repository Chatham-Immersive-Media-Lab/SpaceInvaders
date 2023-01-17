// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    [SerializeField]
    private AlienController[] _aliens;
    public int alienCount;
    public bool WinCondition;
    // Use this for initialization
    void Start ()
    {
        WinCondition = false;
        _aliens = FindObjectsOfType<AlienController>();
        alienCount = _aliens.Length;
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
}
