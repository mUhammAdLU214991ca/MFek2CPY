// 代码生成时间: 2025-09-12 23:55:36
using System;
using System.Collections.Generic;

// 库存项类
public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public InventoryItem(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}

// 库存管理器类
public class InventoryManager
{
    private Dictionary<int, InventoryItem> inventory;

    public InventoryManager()
    {
        inventory = new Dictionary<int, InventoryItem>();
    }

    // 添加库存项
    public void AddItem(int id, string name, int quantity)
    {
        if (inventory.ContainsKey(id))
        {
            throw new ArgumentException("Item with the same ID already exists.");
        }

        inventory.Add(id, new InventoryItem(id, name, quantity));
    }

    // 更新库存项数量
    public void UpdateQuantity(int id, int newQuantity)
    {
        if (!inventory.ContainsKey(id))
        {
            throw new KeyNotFoundException("Item not found.");
        }

        inventory[id].Quantity = newQuantity;
    }

    // 移除库存项
    public bool RemoveItem(int id)
    {
        return inventory.Remove(id);
    }

    // 获取库存项
    public InventoryItem GetItem(int id)
    {
        if (!inventory.TryGetValue(id, out InventoryItem item))
        {
            throw new KeyNotFoundException("Item not found.");
        }

        return item;
    }

    // 列出所有库存项
    public List<InventoryItem> ListItems()
    {
        return new List<InventoryItem>(inventory.Values);
    }
}

// 主程序类
public class Program
{
    public static void Main()
    {
        try
        {
            InventoryManager manager = new InventoryManager();

            // 添加库存项
            manager.AddItem(1, "Apples", 100);
            manager.AddItem(2, "Bananas", 150);

            // 更新库存项数量
            manager.UpdateQuantity(1, 120);

            // 获取并打印库存项详情
            InventoryItem item = manager.GetItem(1);
            Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");

            // 列出所有库存项
            foreach (InventoryItem invItem in manager.ListItems())
            {
                Console.WriteLine($"ID: {invItem.Id}, Name: {invItem.Name}, Quantity: {invItem.Quantity}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}