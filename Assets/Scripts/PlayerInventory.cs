using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // List of the items that the player is holding
    public List<InventoryItem> items = new List<InventoryItem>();
    // Maximum capacity of inventory
    public int inventoryCapacity = 5;

    public bool AddItem(InventoryItem item) {
        if (items.Count >= inventoryCapacity) {
            return false;
        }

        if (items.Contains(item)) {
            return false;
        }

        items.Add(item);

        return true;
    }

    public bool HasItem(InventoryItem item) {
        return items.Contains(item);
    }

    public bool HasItem(string itemName) {
        foreach (InventoryItem i in items) {
            if (i.itemName == itemName) {
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(string itemName) {
        int foundIdx = -1;

        for (int i = 0; i < items.Count; i++) {
            var curItem = items[i];

            if (curItem.itemName == itemName) {
                foundIdx = i;
                break;
            }
        }

        if (foundIdx != -1) {
            items.RemoveAt(foundIdx);
        }
    }

    public List<InventoryItem> GetItems() {
        return items;
    }
}
