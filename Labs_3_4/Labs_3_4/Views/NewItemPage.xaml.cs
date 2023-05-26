using Labs_3_4.Models;
using Labs_3_4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Labs_3_4.Views
{
    public partial class NewItemPage : ContentPage
    {
        private NewItemViewModel _model;

        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            _model = new NewItemViewModel();
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
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            _model.DividedBath = e.Value;
        }
    }
}