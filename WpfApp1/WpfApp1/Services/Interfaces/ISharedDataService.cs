using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.Model;

namespace WpfApp1.Services.Interfaces
{
    public interface ISharedDataService
    {
        ObservableCollection<Item> Items { get; }

        //Metodos async
        Task InitializeAsync();
        Task AddItemAsync(string name);
        Task ClearItemAsync();

        //evento para notificar cambios en la coleccion
        event EventHandler DataChanged;
        //void AddItem(Item item);
    }
}
