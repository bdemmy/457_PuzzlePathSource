using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2EndDoor : MonoBehaviour
{

    public GameObject Player;


    // Check if the player walked over the exit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collided with the player
        if (collision.gameObject == Player )
        {
            // Finished the level, do something here
            SceneManager.LoadScene("Level1");
        }
    }
}
