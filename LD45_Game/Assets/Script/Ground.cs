using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {
        // Does the other collider have the tag "Player"?
        if (c.gameObject.tag == "Player")
        {
        // Yes it does. Destroy the entire gameObject.
        
    
        }
    }
}
