using Labs_3_4.Models;
using Labs_3_4.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labs_3_4.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewItemViewModel : BaseViewModel
    {
        private string itemId;
        private string street;
        private bool dividedBath;
        private string buildingType;
        private short buildYear;
        private int roomCount;
        private double square;
        public int floor;

        private Item _currentItem;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(street)
                && !String.IsNullOrWhiteSpace(buildingType)
                && buildYear > 1900 && buildYear <= DateTime.Now.Year
                && roomCount > 0 & roomCount <= 9
                && square > 0 && square < 1000
                && floor >= 0;
        }

        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }

        public bool DividedBath
        {
            get => dividedBath;
            set => SetProperty(ref dividedBath, value);
        }

        public string BuildingType
        {
            get => buildingType;
            set => SetProperty(ref buildingType, value);
        }

        public short BuildYear
        {
            get => buildYear;
            set => SetProperty(ref buildYear, value);
        }

        public int RoomCount
        {
            get => roomCount;
            set => SetProperty(ref roomCount, value);
        }

        public double Square
        {
            get => square;
            set => SetProperty(ref square, value);
        }

        public int Floor
        {
            get => floor;
            set => SetProperty(ref floor, value);
        }
        public string Id { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("../..");
        }

        private async void OnSave()
        {
            Item newItem = _currentItem.BuildFinish(DividedBath, BuildingType, BuildYear, Square);

            await DataStore.UpdateItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("../..");
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                _currentItem = await DataStore.GetItemAsync(itemId);
                Id = _currentItem.Id;
                Street = _currentItem.Street;
                DividedBath = _currentItem.DividedBathroom;
                BuildingType = _currentItem.BuildingType;
                BuildYear = _currentItem.BuildYear;
                RoomCount = _currentItem.RoomCount;
                Square = _currentItem.Square;
                Floor = _currentItem.Floor;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
