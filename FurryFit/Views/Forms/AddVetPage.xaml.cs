﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVetPage : ContentPage
    {
        public AddVetPage()
        {
            InitializeComponent();
        }

        private void BtnCancel_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}