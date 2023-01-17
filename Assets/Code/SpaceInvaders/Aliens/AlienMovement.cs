// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour {
    public float moveBy = 1f;
    int numberOfMoves = 0;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ChangePosition", 0, 1);
    }

    void ChangePosition()
    {
        Vector3 position = gameObject.transform.position;
        Vector3 newPosition;

        if (numberOfMoves % 10 == 0 && numberOfMoves > 0)
        {
            moveBy = moveBy * -1;
            newPosition = new Vector3(position.x + moveBy,
                                      position.y - Mathf.Abs(moveBy),
                                      0f);

        }
        else
        {
            newPosition = new Vector3(position.x + moveBy, position.y, 0f);
        }

        gameObject.transform.position = newPosition;
        numberOfMoves++;
    }
}
