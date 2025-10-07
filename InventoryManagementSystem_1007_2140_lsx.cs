// 代码生成时间: 2025-10-07 21:40:44
using System;
using System.Collections.Generic;

// 库存项类，用于表示库存中的单个物品
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

// 库存管理系统类
public class InventoryManagementSystem
{
    private List<InventoryItem> items;

    public InventoryManagementSystem()
    {
        items = new List<InventoryItem>();
    }

    // 添加物品到库存
    public void AddItem(InventoryItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        if (items.Exists(i => i.Id == item.Id))
        {
            throw new InvalidOperationException("Item with the same ID already exists.");
        }
        items.Add(item);
    }

    // 从库存中移除物品
    public void RemoveItem(int itemId)
    {
        var item = items.Find(i => i.Id == itemId);
        if (item == null)
        {
            throw new InvalidOperationException("Item not found.");
        }
        items.Remove(item);
    }

    // 更新库存中物品的数量
    public void UpdateQuantity(int itemId, int newQuantity)
    {
        var item = items.Find(i => i.Id == itemId);
        if (item == null)
        {
            throw new InvalidOperationException("Item not found.");
        }
        if (newQuantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity cannot be negative.");
        }
        item.Quantity = newQuantity;
    }

    // 获取库存中所有物品的列表
    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(items);
    }

    // 搜索库存中的物品
    public List<InventoryItem> SearchItems(string itemName)
    {
        return items.FindAll(i => i.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }
}
