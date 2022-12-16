using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
/*
 
 Source file Name - Gem.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 12/16/2022 
 Program description: Just a script for a GEM, when we will collide with it(trigger) we want to destroy the gem and add score to our player.

 */
public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().Score++;
            collision.gameObject.GetComponent<PlayerBehaviour>().scoreText.text = "Score: " + collision.gameObject.GetComponent<PlayerBehaviour>().Score;
            Destroy(this.gameObject);
        }
    }
}
