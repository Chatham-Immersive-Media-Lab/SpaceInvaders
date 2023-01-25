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

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(fireBulletKey))
        {
            
            TankBullet bullet = Instantiate(bulletPrefab, firePoint);
            bullet.name = "Bullet Bill";
            
            bullet.transform.position += new Vector3(1, 0, 0);
            TankBullet bullet2 = Instantiate(bulletPrefab, firePoint);
            bullet2.transform.position += new Vector3(-1, 0, 0);
        }
 
    }
	
}
