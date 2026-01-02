using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Services.Interfaces;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class MainWindowViewModel
    {
        private readonly ISharedDataService _dataService;

        // Propiedad que expone la colección a la UI
        public ObservableCollection<Item> Items => _dataService.Items;

        // Constructor con DI
        public MainWindowViewModel(ISharedDataService dataService)
        {
            _dataService = dataService;

            //datos de prueba
            _dataService.AddItem(new Item
            {
                Name = "Item 1",
                Created = DateTime.UtcNow
            });
        }

    }
}
