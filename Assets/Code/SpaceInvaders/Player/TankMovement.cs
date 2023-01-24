// ----------------------------------------------------------------------------
//  Chatham University
//  JAN 2023
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Moves Player Tank Left and Right within a boundary
/// </summary>
public class TankMovement : MonoBehaviour 
{ 
    [SerializeField] 
    private float moveRate;
    [Header("Input Axis")]
    [SerializeField]
    private float horizontalInput;
    [Header("Boundary")]
    [SerializeField] private int min;
    [SerializeField] private int max;
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput,0) * (Time.deltaTime * moveRate));
        
        // Check Boundary
        if (transform.position.x < min)
        {
            transform.position = new Vector2(min, 0);
        }
        else if(transform.position.x > max)
        {
            transform.position = new Vector2(max, 0);
        }
    }
}
