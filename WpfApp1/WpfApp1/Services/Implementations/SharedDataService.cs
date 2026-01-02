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

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
