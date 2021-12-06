using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchScript : MonoBehaviour {
    // References to left and right torches
    public GameObject leftTorch;
    public GameObject rightTorch;

    // References to left and right torch scripts
    TorchScript leftTorchScript;
    TorchScript rightTorchScript;

    // Local SpriteRenderer
    SpriteRenderer spriteRenderer;

    public Sprite offLight;
    public Sprite onLight;

    //variables to detect player interaction
    public GameObject player;
    public float interactionRadius;

    // Private state
    public Light2D lightSource;

    public bool isLit;

    private void Awake() {
        lightSource = GetComponent<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        leftTorchScript = leftTorch.GetComponent<TorchScript>();
        rightTorchScript = rightTorch.GetComponent<TorchScript>();

        UpdateLighting();
    }

    private void Update() {
        float dist = Vector3.Distance(player.transform.position, transform.position); //distance from torch from player

        if (dist < interactionRadius) // if player is within interaction circle
        {
            if (Input.GetKeyDown("e")) //if e is pressed
            {
                Toggle(true); //flip lights
            }
        }
    }

    public void Toggle(bool updateNeighbors = false) {
        if (updateNeighbors) {
            leftTorchScript.Toggle();
            rightTorchScript.Toggle();
        }

        isLit = !isLit;

        UpdateLighting();
    }

    void UpdateLighting() {
        if (isLit) {
            lightSource.enabled = true;
            spriteRenderer.sprite = onLight;
        }
        else {
            lightSource.enabled = false;
            spriteRenderer.sprite = offLight;
        }
    }
}
