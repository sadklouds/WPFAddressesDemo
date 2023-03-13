using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAddressesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISavedAddress
    {
        BindingList<AddressModel> addresses = new BindingList<AddressModel>();

        List<PersonModel> persons = new List<PersonModel>();
        public MainWindow()
        {
            InitializeComponent();
            addressList.ItemsSource = addresses;
            //addressList.DataContext =  nameof(AddressModel.FullAddressValue);
        }

        public void SaveAddress(AddressModel address)
        {
            addresses.Add(address);
        }

        private void addAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressEntry addressEntry = new AddressEntry(this);
            addressEntry.Show();
        }

        private void savePerson_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                firstNameText.Focus();
            }
            else if (string.IsNullOrWhiteSpace(lastNameText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                lastNameText.Focus();
            }
            else
            {
                PersonModel person = new PersonModel()
                {
                    FirstName = firstNameText.Text,
                    LastName = lastNameText.Text,
                    Addresses = addresses.ToList()
                };

                persons.Add(person);
                MessageBox.Show($"{firstNameText.Text} {lastNameText.Text} was added.");
            }
        }
    }
}
