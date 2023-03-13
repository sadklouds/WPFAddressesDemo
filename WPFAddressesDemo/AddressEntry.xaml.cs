using DemoLibrary;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPFAddressesDemo
{
    /// <summary>
    /// Interaction logic for AddressEntry.xaml
    /// </summary>
    public partial class AddressEntry : Window
    {
        ISavedAddress _parent;
        public AddressEntry(ISavedAddress parent)
        {
            InitializeComponent();

            _parent = parent;
        }

        private void saveAddress_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(streetAddressText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                streetAddressText.Focus();
            }
            else if (string.IsNullOrWhiteSpace(cityText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                cityText.Focus();
            }
            else if (string.IsNullOrWhiteSpace(countyText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                countyText.Focus();
            }
            else if (string.IsNullOrWhiteSpace(postcodeText.Text))
            {
                MessageBox.Show($"Please fill all fields before clicking save", "Blank Field", MessageBoxButton.OK, MessageBoxImage.Error);
                postcodeText.Focus();
            }
            else
            {
                AddressModel address = new AddressModel()
                {
                    StreetAddress = streetAddressText.Text,
                    City = cityText.Text,
                    County = countyText.Text,
                    PostCode = postcodeText.Text
                };

                _parent.SaveAddress(address);

                this.Close();
            }
        }
    }
}
