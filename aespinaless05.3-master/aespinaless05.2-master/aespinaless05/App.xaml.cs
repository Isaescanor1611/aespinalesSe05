﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aespinaless05
{


    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new insertar());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
