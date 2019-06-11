using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewDL : Page
    {
        public NewDL()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)

        {

            Customers s = (Customers)e.Parameter;

            namebox.Text = s.Name;
            fathername.Text = s.FName;
            emailbox.Text = s.Email;
            addressbox.Text = s.Address;
            aadharbox.Text = s.aadhar;
            mobilebox.Text = s.Mobile;
            identificationbox.Text = s.Identity;
            vehiclebox.Text = s.vehicletype;
            dobbox.Text = s.DOB;
        }

        private void DLButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FinalDL));
        }
    }
}
