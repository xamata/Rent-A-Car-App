using RentACarAppLibrary.Data;
using RentACarAppLibrary.Models;
using System;
using System.Windows;

namespace RentACarApp.Desktop
{
    /// <summary>
    /// Interaction logic for CheckInForm.xaml
    /// </summary>
    public partial class CheckInForm : Window
    {
        private readonly IDatabaseData _db;
        private RentalFullModel _data = null;

        public CheckInForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public void PopulateCheckInInfo(RentalFullModel data)
        {
            _data = data;
            firstNameText.Text = _data.FirstName;
            lastNameText.Text = _data.LastName;
            makeText.Text = _data.Make;
            licenseText.Text = _data.License;
            totalCostText.Text = String.Format("{0:C}", _data.TotalCost);
        }

        private void checkInUser_Click(object sender, RoutedEventArgs e)
        {
            _db.CheckInGuest(_data.Id);
            this.Close();
        }
    }
}
