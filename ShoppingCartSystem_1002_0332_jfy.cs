// 代码生成时间: 2025-10-02 03:32:23
using System;
using System.Collections.Generic;
using UnityEngine;

// ShoppingCartItem represents an item in the shopping cart
[System.Serializable]
public class ShoppingCartItem
{
    public string ItemName;
    public int Quantity;

    public ShoppingCartItem(string itemName, int quantity)
    {
        ItemName = itemName;
        Quantity = quantity;
    }
}

// ShoppingCart class that manages the shopping cart operations
public class ShoppingCart
{
    private List<ShoppingCartItem> items;

    public ShoppingCart()
    {
        items = new List<ShoppingCartItem>();
    }

    // Adds an item to the shopping cart
    public void AddItem(string itemName, int quantity)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Debug.LogError("Item name cannot be null or empty.");
            return;
        }

        if (quantity <= 0)
        {
            Debug.LogError("Quantity must be greater than zero.");
            return;
        }

        var existingItem = items.Find(item => item.ItemName == itemName);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            items.Add(new ShoppingCartItem(itemName, quantity));
        }
    }

    // Removes an item from the shopping cart
    public void RemoveItem(string itemName)
    {
        var itemToRemove = items.Find(item => item.ItemName == itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }
        else
        {
            Debug.LogWarning("Item not found in the shopping cart.");
        }
    }

    // Clears the shopping cart
    public void ClearCart()
    {
        items.Clear();
    }

    // Gets the total number of items in the cart
    public int GetTotalItems()
    {
        return items.Sum(item => item.Quantity);
    }

    // Displays the contents of the shopping cart
    public void DisplayCart()
    {
        foreach (var item in items)
        {
            Debug.Log($"Item: {item.ItemName}, Quantity: {item.Quantity}");
        }
    }
}
