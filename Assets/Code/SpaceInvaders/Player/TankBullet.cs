// ----------------------------------------------------------------------------
//  University of Pittsburgh  
//  GamesEdu Workshop #2
//  19 SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour 
{
    [Header("How long until I destroy myself?")]
    public float lifeSpan;
    [Header("How fast do I go?")]
    public float bulletSpeed;
    [Header("What do I collide with?")]
    public string[] collisionTags;

	// Use this for initialization
	void Start () 
    {
        transform.parent = null;            // Unparent the bullet so it does not follow the Tank that fired it.
        Destroy(gameObject, lifeSpan);	    // Destroy me after a specified time.
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed); // Move Up over time by the speed
    }
    private void OnTriggerEnter2D(Collider2D collisonObject)
    {
        foreach (var collisionTag in collisionTags)
        {
            if (collisonObject.tag.Equals(collisionTag))
            {
                collisonObject.gameObject.SetActive(false); // Deactivate the object I collided with
                Destroy(gameObject);             // THEN Destroy myself!
            }                
        }
    }
}
