using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingsScript : MonoBehaviour
{
    //different sprites for model and acutal painting
    public Sprite painting;
    public GameObject UIPaintingImage;

    //variables to detect player interaction
    public GameObject player;
    public float interactionRadius;

    // Reference to UIPaintingImage image object
    Image paintingImage;

    private void Awake() {
        paintingImage = UIPaintingImage.GetComponent<Image>();
        UIPaintingImage.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (!UISystem.isInputLocked) {
            float dist = Vector3.Distance(player.transform.position, transform.position); //distance to painting from player

            if (dist < interactionRadius) { // if player is within interaction circle
                if (Input.GetKeyDown("e")) {  //if e is pressed
                    paintingImage.sprite = painting;
                    UISystem.LockInput(gameObject);
                    UIPaintingImage.SetActive(true);
                }
            }
        }

        else if (UISystem.isInputLocked && UISystem.focusedGameObject == gameObject) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("e")) {
                UISystem.UnlockInput();
                UIPaintingImage.SetActive(false);
            }
        }
    }
}

