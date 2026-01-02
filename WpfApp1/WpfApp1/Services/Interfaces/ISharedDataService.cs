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
        void AddItem(Item item);
    }
}
