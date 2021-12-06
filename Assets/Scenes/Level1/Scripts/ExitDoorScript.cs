using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    public GameObject ExitTileset;
    public GameObject Player;

    public float ActivationRadius = 1.5f;

    // Keep track of whether or not the player has opened the exit
    bool exitOpened = false;

    // Update is called once per frame
    void Update() {
        float dist = Vector3.Distance(Player.transform.position, transform.position); //distance from torch from player

        if (dist < ActivationRadius) // if player is within interaction circle
        {
            if (Input.GetKeyDown("e") && Player.GetComponent<PlayerInventory>().HasItem("Level01_Key01")) //if e is pressed
            {
                Debug.Log("Removing Item");

                Player.GetComponent<PlayerInventory>().RemoveItem("Level01_Key01");

                // Disable the grate over the lock and allow the player to exit through the grate
                ExitTileset.SetActive(false);
                exitOpened = true;
            }
        }
    }

    // Check if the player walked over the exit
    private void OnTriggerEnter2D(Collider2D collision) {
        // Collided with the player
        if (collision.gameObject == Player && exitOpened) {
            // Finished the level, do something here
            SceneManager.LoadScene("Level2");
        }
    }
}
