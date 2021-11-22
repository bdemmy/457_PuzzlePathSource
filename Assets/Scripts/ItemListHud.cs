using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListHud : MonoBehaviour
{
    // Reference to the player so we can see their inventory
    public GameObject player;
    public List<GameObject> hudItemSlots;

    // Private references to components/etc
    PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerItems = inventory.GetItems();

        for (int i = 0; i < hudItemSlots.Count; i++) {
            hudItemSlots[i].GetComponent<Image>().enabled = false;
            if (i > playerItems.Count - 1) {
                break;
            }

            var item = playerItems[i];
            hudItemSlots[i].GetComponent<Image>().sprite = item.inventorySprite;
            hudItemSlots[i].GetComponent<Image>().enabled = true;
        }
    }
}
