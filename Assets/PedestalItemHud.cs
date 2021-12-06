using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestalItemHud : MonoBehaviour {
    // Reference to the player so we can see their inventory
    public GameObject player;

    // Private references to components/etc
    PlayerInventory inventory;

    // Start is called before the first frame update
    void Start() {
        inventory = player.GetComponent<PlayerInventory>();
    }

    private void Update() {
        if (inventory.pedestalItem != null) {
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = inventory.pedestalItem.inventorySprite;
        }
        else {
            GetComponent<Image>().enabled = false;
        }
    }
}
