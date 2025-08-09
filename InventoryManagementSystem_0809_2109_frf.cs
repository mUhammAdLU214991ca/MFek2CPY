// 代码生成时间: 2025-08-09 21:09:35
 * The system is designed to be easy to understand, maintain, and extend.
 */

using System;
using System.Collections.Generic;

namespace InventorySystem
{
    // Define a class to represent an inventory item
    public class InventoryItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(int id, string name, int quantity)
        {
            ItemID = id;
            ItemName = name;
            Quantity = quantity;
        }
    }

    // Define the Inventory Manager class
    public class InventoryManager
    {
        private Dictionary<int, InventoryItem> inventory;

        public InventoryManager()
        {
            inventory = new Dictionary<int, InventoryItem>();
        }

        // Method to add an item to the inventory
        public void AddItem(int id, string name, int quantity)
        {
            if (inventory.ContainsKey(id))
            {
                throw new ArgumentException("Item with the same ID already exists in the inventory.");
            }

            inventory.Add(id, new InventoryItem(id, name, quantity));
        }

        // Method to remove an item from the inventory
        public bool RemoveItem(int id)
        {
            if (inventory.ContainsKey(id))
            {
                inventory.Remove(id);
                return true;
            }
            else
            {
                Console.WriteLine("Item with ID {0} not found in the inventory.", id);
                return false;
            }
        }

        // Method to get item details
        public InventoryItem GetItem(int id)
        {
            if (inventory.TryGetValue(id, out InventoryItem item))
            {
                return item;
            }
            else
            {
                throw new KeyNotFoundException("Item with ID not found in the inventory.");
            }
        }
    }
}
