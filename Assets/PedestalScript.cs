using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PedestalScript : MonoBehaviour {
    public string riddle = "SET ME";
    public string correctItem = "SET ME";

    public GameObject player;
    public float interactDistance = 1.5f;
    public GameObject itemDisplay;

    public GameObject HUDPedestal;
    public GameObject HUDPedestalTextGO;

    public bool correct;

    private PlayerInventory inventory;
    private PedestalItem heldItem;
    private SpriteRenderer displaySprite;

    private TextMeshProUGUI hudPedestalText;

    // Start is called before the first frame update
    void Start() {
        inventory = player.GetComponent<PlayerInventory>();
        displaySprite = itemDisplay.GetComponent<SpriteRenderer>();
        hudPedestalText = HUDPedestalTextGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        // If we are in range and hit E
        if (Input.GetKeyDown("e") && Vector2.Distance(player.transform.position, transform.position) < interactDistance) {
            // If the player is holding one of the items
            if (inventory.pedestalItem != null) {
                if (heldItem != null) {
                    PedestalItem temp = heldItem;
                    heldItem = inventory.pedestalItem;
                    inventory.pedestalItem = temp;
                } else {
                    heldItem = inventory.pedestalItem;
                    inventory.pedestalItem = null;
                }
            } else {
                if (heldItem != null) {
                    inventory.pedestalItem = heldItem;
                    heldItem = null;
                }
            }

            UpdateSprite();
        }

        if (Vector2.Distance(player.transform.position, transform.position) < interactDistance) {
            hudPedestalText.text = riddle;
        }

        correct = IsCorrect();
    }

    void UpdateSprite() {
        if (heldItem != null) {
            displaySprite.sprite = heldItem.worldSprite;
        } else {
            displaySprite.sprite = null;
        }
    }

    public bool IsCorrect() {
        if (heldItem == null) {
            return false;
        }

        return heldItem.itemName == correctItem;
    }
}
