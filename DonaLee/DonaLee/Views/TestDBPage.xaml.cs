﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonaLee.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DonaLee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestDBPage : ContentPage
    {
        conection conection = new conection();
        public TestDBPage()
        {
            InitializeComponent();
        }
     
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsers = await conection.GetAllUsers();
            lstUsers.ItemsSource = allUsers;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await conection.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allUsers = await conection.GetAllUsers();
            lstUsers.ItemsSource = allUsers;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await conection.GetPerson(Convert.ToInt32(txtId.Text));
            if (person != null)
            {
                txtId.Text = person.IdUsuario.ToString();
                txtName.Text = person.NombresUsuario;
                await DisplayAlert("Success", "User Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No User Available", "OK");
            }

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await conection.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Updated Successfully", "OK");
            var allUsers = await conection.GetAllUsers();
            lstUsers.ItemsSource = allUsers;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await conection.DeletePerson(Convert.ToInt32(txtId.Text));
            await DisplayAlert("Success", "Person Deleted Successfully", "OK");
            var allUsers = await conection.GetAllUsers();
            lstUsers.ItemsSource = allUsers;
        }



    }
}