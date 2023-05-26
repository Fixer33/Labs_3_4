using Labs_3_4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_3_4.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = LoadData();

            App.Sleep += OnAppSleep;
        }

        private void OnAppSleep()
        {
            SaveData(items);
        }

        ~MockDataStore()
        {
            App.Sleep -= OnAppSleep;
        }

        public void SetItems(List<Item> items)
        {
            this.items.Clear();
            this.items.AddRange(items);
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        private readonly string DATA_FILE_PATH = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "items.json");


        private List<Item> LoadData()
        {
            if (File.Exists(DATA_FILE_PATH) == false)
                return new List<Item>();

            string content = File.ReadAllText(DATA_FILE_PATH);
            if (string.IsNullOrEmpty(content))
                return new List<Item>();

            try
            {
                return JsonConvert.DeserializeObject<List<Item>>(content);
            }
            catch
            {
                return new List<Item>();
            }
        }

        private void SaveData(List<Item> items)
        {
            if (File.Exists(DATA_FILE_PATH))
                File.Delete(DATA_FILE_PATH);

            File.Create(DATA_FILE_PATH).Close();
            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText(DATA_FILE_PATH, json);
        }
    }
}