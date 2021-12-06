using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeverScript : MonoBehaviour
{

    // Local SpriteRenderer
    SpriteRenderer spriteRenderer;

    public Sprite offLever;
    public Sprite onLever;

    public GameObject tilePath;

    //variables to detect player interaction
    public GameObject player;
    public float interactionRadius;

    public GameObject torchOne;
    torchScript torchScriptOne;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        torchScriptOne = torchOne.GetComponent<torchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //distance from torch from player

        if (dist < interactionRadius) // if player is within interaction circle
        {
            if (Input.GetKeyDown("e")) //if e is pressed
            {
                torchScriptOne.Toggle(); //flip lights
                spriteRenderer.sprite = onLever;

                tilePath.GetComponent<TilemapCollider2D>().enabled = !tilePath.GetComponent<TilemapCollider2D>().enabled;
            }
        }
    }
}
