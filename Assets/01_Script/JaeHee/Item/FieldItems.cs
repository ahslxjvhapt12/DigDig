using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.name = _item.name;
        item.image = _item.image;
        item.Type = _item.Type;
        item.useItems = _item.useItems;

        image.sprite = item.image;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
