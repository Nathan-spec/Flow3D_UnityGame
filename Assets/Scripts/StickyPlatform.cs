using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyComponent : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //If the object has collided with the plane
        if (collision.gameObject.name == "Player")
        {
            // make the player a child of the transform
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
         if (collision.gameObject.name == "Player")
        {
            //UnParent the Player
            collision.gameObject.transform.SetParent(null);
        }
    }
}
