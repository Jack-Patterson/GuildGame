using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace com.Halkyon.Items
{
    public class ItemManager : ExtendedMonoBehaviour
    {
        public static ItemManager Instance;
        private List<Item> _items = new();

        public List<Item> Items => _items;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            LoadItems();
        }
        
        public Item GetItemById(string itemId)
        {
            return _items.Find(item => item.Id == itemId);
        }
        
        public Item GetItemByName(string itemName)
        {
            return _items.Find(item => item.Name == itemName);
        }
        
        public List<Item> GetItemsByCategory(string category)
        {
            return _items.FindAll(item => item.Category == category);
        }
        
        public List<Item> GetItemsByCategory(string category, string subCategory)
        {
            return _items.FindAll(item => item.Category == category && item.SubCategory == subCategory);
        }
        
        public List<Item> GetItemsByCondition(Func<Item, bool> filter)
        {
            return _items.Where(filter).ToList();
        }

        private void LoadItems()
        {
            TextAsset file = Resources.Load<TextAsset>("Interaction/Items");
            _items = JsonConvert.DeserializeObject<List<Item>>(file.text);
        }
    }
}