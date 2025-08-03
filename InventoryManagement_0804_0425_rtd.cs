// 代码生成时间: 2025-08-04 04:25:43
using System;
using System.Collections.Generic;

// 定义一个库存管理系统
public class InventoryManagement
{
    // 用于存储库存项的字典
    private Dictionary<string, int> inventory;

    // 构造函数，初始化库存
    public InventoryManagement()
    {
        inventory = new Dictionary<string, int>();
    }

    // 添加库存项
    public void AddItem(string itemId, int quantity)
    {
        if (inventory.ContainsKey(itemId))
        {
            inventory[itemId] += quantity;
        }
        else
        {
            inventory.Add(itemId, quantity);
        }
    }

    // 移除库存项
    public bool RemoveItem(string itemId, int quantity)
    {
        if (inventory.ContainsKey(itemId) && inventory[itemId] >= quantity)
        {
            inventory[itemId] -= quantity;
            if (inventory[itemId] <= 0)
            {
                inventory.Remove(itemId);
            }
            return true;
        }
        else
        {
            Console.WriteLine("Error: Not enough inventory or item does not exist.");
            return false;
        }
    }

    // 获取库存项的数量
    public int GetQuantity(string itemId)
    {
        if (inventory.ContainsKey(itemId))
        {
            return inventory[itemId];
        }
        else
        {
            Console.WriteLine("Error: Item does not exist.");
            return 0;
        }
    }

    // 打印所有库存项
    public void PrintInventory()
    {
        foreach (var item in inventory)
        {
            Console.WriteLine($"Item ID: {item.Key}, Quantity: {item.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        InventoryManagement inventory = new InventoryManagement();

        // 演示添加、移除和打印库存项
        inventory.AddItem("A123", 10);
        inventory.AddItem("B456", 20);
        inventory.PrintInventory();

        if (inventory.RemoveItem("A123", 5))
        {
            Console.WriteLine("Item removed successfully.");
        }

        inventory.PrintInventory();
    }
}