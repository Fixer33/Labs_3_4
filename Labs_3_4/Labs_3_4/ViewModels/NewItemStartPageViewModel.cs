using Labs_3_4.Models;
using Labs_3_4.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Labs_3_4.ViewModels
{
    public class NewItemBaseViewModel : BaseViewModel
    {
        private string street;
        private int roomCount;
        public int floor;

        public Command NextCommand { get; }
        public Command CancelCommand { get; }

        public NewItemBaseViewModel()
        {
            NextCommand = new Command(OnNext, ValidateNext);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => NextCommand.ChangeCanExecute();
        }

        private bool ValidateNext()
        {
            return !String.IsNullOrWhiteSpace(street)
                && roomCount > 0 & roomCount < 9
                && floor >= 0;
        }

        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }

        public int RoomCount
        {
            get => roomCount;
            set => SetProperty(ref roomCount, value);
        }

        public int Floor
        {
            get => floor;
            set => SetProperty(ref floor, value);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnNext()
        {
            Item newItem = Item.BuildStart(Guid.NewGuid().ToString(), Street, RoomCount, Floor);

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"{nameof(NewItemPage)}?{nameof(NewItemViewModel.ItemId)}={newItem.Id}");
        }
    }
}
