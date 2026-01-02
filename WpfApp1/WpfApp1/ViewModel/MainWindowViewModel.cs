using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Services.Interfaces;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly ISharedDataService _dataService;

        // Propiedad que expone la colección del servicio
        public ObservableCollection<Item> Items => _dataService.Items;

        // Propiedades observables (CommunityToolkit las genera automáticamente)
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
        private string _newItemName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
        [NotifyCanExecuteChangedFor(nameof(LoadDataCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearItemsCommand))]
        private bool _isLoading;

        // Constructor
        public MainWindowViewModel(ISharedDataService dataService)
        {
            _dataService = dataService;

            // Suscribirse a cambios del servicio
            _dataService.DataChanged += OnDataChanged;

            // NOTA: No podemos llamar directamente a un command en el constructor
            // En su lugar, cargamos datos de forma diferente
            _ = InitializeAsync();
        }

        // Método para inicialización async
        private async Task InitializeAsync()
        {
            await LoadDataAsync();
        }

        // Command para cargar datos
        [RelayCommand]
        private async Task LoadDataAsync()
        {
            IsLoading = true;
            try
            {
                await _dataService.InitializeAsync();
            }
            finally
            {
                IsLoading = false;
            }
        }

        // Command para añadir item
        [RelayCommand(CanExecute = nameof(CanAddItem))]
        private async Task AddItemAsync()
        {
            IsLoading = true;
            try
            {
                await _dataService.AddItemAsync(NewItemName);
                NewItemName = string.Empty; // Limpiar después de añadir
            }
            finally
            {
                IsLoading = false;
            }
        }

        // Método que valida si se puede añadir
        private bool CanAddItem()
        {
            return !string.IsNullOrWhiteSpace(NewItemName) && !IsLoading;
        }

        // Command para limpiar items
        [RelayCommand]
        private async Task ClearItemsAsync()
        {
            IsLoading = true;
            try
            {
                await _dataService.ClearItemAsync();
            }
            finally
            {
                IsLoading = false;
            }
        }

        // Método llamado cuando el servicio notifica cambios
        private void OnDataChanged(object sender, System.EventArgs e)
        {
            // Notificar a la UI que la propiedad Items ha cambiado
            OnPropertyChanged(nameof(Items));
        }




    }
}
