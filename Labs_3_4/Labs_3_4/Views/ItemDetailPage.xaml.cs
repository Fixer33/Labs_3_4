using Labs_3_4.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Labs_3_4.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel _model;

        public ItemDetailPage()
        {
            InitializeComponent();
            _model = new ItemDetailViewModel();
            BindingContext = _model;

            Appearing += AppearingHandler;
            BuildingYearInp.TextChanged += BuildingYearChanged;
        }

        private void BuildingYearChanged(object sender, TextChangedEventArgs e)
        {
            _model.BuildYear = short.Parse(BuildingYearInp.Text);
        }

        private void AppearingHandler(object sender, System.EventArgs e)
        {
            DividedBathToggle.IsToggled = _model.DividedBath;
            BuildingTypePicker.SelectedItem = _model.BuildingType;
            BuildingYearInp.Text = _model.BuildYear.ToString();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            _model.DividedBath = e.Value;
        }

        private async void DeleteClicked(object sender, System.EventArgs e)
        {
            var result = await this.DisplayAlert("Водтверждение", "Вы действительно хотите удалить запись?", "Да", "Нет");
            if (result)
            {
                _model.DeleteCommand.Execute(null);
            }
        }
    }
}