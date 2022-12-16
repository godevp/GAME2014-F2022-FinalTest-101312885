using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
