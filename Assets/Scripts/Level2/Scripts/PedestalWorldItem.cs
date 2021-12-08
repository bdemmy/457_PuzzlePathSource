using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalWorldItem : MonoBehaviour
{
    public List<GameObject> pedestalItems;
    public Sprite worldSprite;
    public Sprite hudSprite;
    public GameObject player;
    public string itemName = "UNSET";

    PedestalItem inventoryItem;
    PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = worldSprite;

        inventoryItem = new PedestalItem(itemName, hudSprite, worldSprite);
        inventory = player.GetComponent<PlayerInventory>();
    }

    private void Update() {

        if (Input.GetKeyDown("e")) {  //if e is pressed
            if (Vector2.Distance(player.transform.position, transform.position) < 1.5) {
                if (inventory.pedestalItem != null) {
                    foreach (GameObject g in pedestalItems) {
                        if (g.name == inventory.pedestalItem.itemName) {
                            // Drop the item and set the reference to the player
                            GameObject droppedItem = Instantiate(g, player.transform.position, Quaternion.identity);
                            droppedItem.GetComponent<PedestalWorldItem>().player = player;

                            // Set inventory item and destroy
                            inventory.pedestalItem = inventoryItem;
                            Destroy(gameObject);
                            return;
                        }
                    }
                }
                else {
                    inventory.pedestalItem = inventoryItem;
                    Destroy(gameObject);
                }
            }
        }
    }
}
