using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets {
    public class InventoryItem : IEquatable<InventoryItem> {
        public string itemName;
        public Sprite inventorySprite;
        public Sprite worldSprite;

        public InventoryItem(string itemName, Sprite inventorySprite, Sprite worldSprite) {
            this.itemName = itemName;
            this.inventorySprite = inventorySprite;
            this.worldSprite = worldSprite;
        }

        public override bool Equals(object obj) {
            return Equals(obj as InventoryItem);
        }

        public bool Equals(InventoryItem other) {
            return other != null &&
                   itemName == other.itemName &&
                   EqualityComparer<Sprite>.Default.Equals(inventorySprite, other.inventorySprite) &&
                   EqualityComparer<Sprite>.Default.Equals(worldSprite, other.worldSprite);
        }

        public override int GetHashCode() {
            int hashCode = -1139624443;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(itemName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(inventorySprite);
            hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(worldSprite);
            return hashCode;
        }

        public static bool operator ==(InventoryItem left, InventoryItem right) {
            return EqualityComparer<InventoryItem>.Default.Equals(left, right);
        }

        public static bool operator !=(InventoryItem left, InventoryItem right) {
            return !(left == right);
        }
    }
}
