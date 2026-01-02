using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.Model;
using WpfApp1.Services.Interfaces;

namespace WpfApp1.Services.Implementations
{
    public class SharedDataService : ISharedDataService
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        public event EventHandler? DataChanged;

        // Simular carga de datos asincrona (como si viniera de DB/API)

        public async Task InitializeAsync()
        {
            await Task.Delay(1000); // Simular retardo de red/BD

            // Datos de ejemplo
            Items.Add(new Item { Name = "Item 1" });

            OnDataChanged();
        }

        public async Task AddItemAsync(string name)
        {
            await Task.Delay(500); // Simular retardo
            Items.Add(new Item { Name = "Primer item" });
            OnDataChanged();
        }

        public async Task ClearItemAsync()
        {
            await Task.Delay(500); // Simular retardo
            Items.Clear();
            OnDataChanged();
        }





        private void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        //public void AddItem(Item item)
        //{
        //    Items.Add(item);
        //}
    }
}
