using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public Sprite worldSprite;
    public Sprite hudSprite;

    public string itemName = "UNSET";

    InventoryItem inventoryItem;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = worldSprite;

        inventoryItem = new InventoryItem(itemName, hudSprite, worldSprite);
    }
     
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
        if (inventory && inventory.AddItem(inventoryItem)) {
            Destroy(gameObject);
        }
    }
}
