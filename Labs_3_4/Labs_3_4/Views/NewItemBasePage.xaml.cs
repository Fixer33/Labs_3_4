using Labs_3_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Labs_3_4.Views
{
    public partial class NewItemBasePage : ContentPage
    {
        public NewItemBasePage()
        {
            InitializeComponent();
            BindingContext = new NewItemBaseViewModel();
        }
    }
}