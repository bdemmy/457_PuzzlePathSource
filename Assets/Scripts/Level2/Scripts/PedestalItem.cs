using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalItem : IEquatable<PedestalItem> {
    public string itemName;
    public Sprite inventorySprite;
    public Sprite worldSprite;

    public PedestalItem(string itemName, Sprite inventorySprite, Sprite worldSprite)
    {
        this.itemName = itemName;
        this.inventorySprite = inventorySprite;
        this.worldSprite = worldSprite;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as PedestalItem);
    }

    public bool Equals(PedestalItem other)
    {
        return other != null &&
               itemName == other.itemName &&
               EqualityComparer<Sprite>.Default.Equals(inventorySprite, other.inventorySprite) &&
               EqualityComparer<Sprite>.Default.Equals(worldSprite, other.worldSprite);
    }

    public override int GetHashCode()
    {
        int hashCode = -1139624443;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(itemName);
        hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(inventorySprite);
        hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(worldSprite);
        return hashCode;
    }

    public static bool operator ==(PedestalItem left, PedestalItem right)
    {
        return EqualityComparer<PedestalItem>.Default.Equals(left, right);
    }

    public static bool operator !=(PedestalItem left, PedestalItem right)
    {
        return !(left == right);
    }
}
