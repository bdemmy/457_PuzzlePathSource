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


    public EdgeCollider2D col1;
    public EdgeCollider2D col2;
    public EdgeCollider2D col3;
    public EdgeCollider2D col4;
    public EdgeCollider2D col5;
    public EdgeCollider2D col6;

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

                col1.enabled = false;
                col2.enabled = false;
                col3.enabled = false;
                col4.enabled = false;
                col5.enabled = false;
                col6.enabled = false;
            }
        }
    }
}
