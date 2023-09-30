using RentACarAppLibrary.Data;
using RentACarAppLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace RentACarApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabaseData _db;

        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }
        private void searchForGuest_Click(object sender, RoutedEventArgs e)
        {
            List<RentalFullModel> rentals = _db.SearchRentals(lastNameText.Text);
            resultsList.ItemsSource = rentals;
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            var checkInForm = App.serviceProvider.GetService<CheckInForm>();
            var model = (RentalFullModel)((Button)e.Source).DataContext;

            checkInForm.PopulateCheckInInfo(model);

            checkInForm.Show();
        }
    }
}
