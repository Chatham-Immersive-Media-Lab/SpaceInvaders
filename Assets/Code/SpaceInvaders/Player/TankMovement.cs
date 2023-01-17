// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves Player Tank via Input Axis
/// </summary>
public class TankMovement : MonoBehaviour 
{
    [SerializeField]
    private float _moveRate;

    [SerializeField, Header("Input Axis")]
    private Vector2 _axisInput; // Think of this Vector 2 as a DPad controller 
    /*public Vector2 AxisInput
    {
        get
        {
            _axisInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return _axisInput;
        }
        private set { _axisInput = value; }
    }*/

    private void Update()
    {
        _axisInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(_axisInput * Time.deltaTime * _moveRate);
    }
}
