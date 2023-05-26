using Labs_3_4.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Labs_3_4.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string street;
        private bool dividedBath;
        private string buildingType;
        private short buildYear;
        private int roomCount;
        private double square;
        public int floor;

        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public ItemDetailViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            DeleteCommand = new Command(OnDelete);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(street)
                && !String.IsNullOrWhiteSpace(buildingType)
                && buildYear > 1900 && buildYear < DateTime.Now.Year
                && roomCount > 0 & roomCount < 5
                && square > 0 && square < 1000
                && floor >= 0;
        }

        private async void OnSave()
        {
            Item newItem = new Item(ItemId, Street, DividedBath, BuildingType, BuildYear, RoomCount, Square, Floor);

            await DataStore.UpdateItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(ItemId);

            await Shell.Current.GoToAsync("..");
        }

        public string Id { get; set; }
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
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Street = item.Street;
                DividedBath = item.DividedBathroom;
                BuildingType = item.BuildingType;
                BuildYear = item.BuildYear;
                RoomCount = item.RoomCount;
                Square = item.Square;
                Floor = item.Floor;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
