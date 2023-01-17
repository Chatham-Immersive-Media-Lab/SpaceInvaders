// ----------------------------------------------------------------------------
//  Chatham University
//  Week 3
//  JANUARY 2023
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fires a bullet from the Players Tank
/// </summary>
public class TankShoot : MonoBehaviour {
    public KeyCode fireBulletKey;
    public TankBullet bulletPrefab;
    public Transform firePoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(fireBulletKey))
        {
            Instantiate(bulletPrefab, firePoint);
        }
    }
}
